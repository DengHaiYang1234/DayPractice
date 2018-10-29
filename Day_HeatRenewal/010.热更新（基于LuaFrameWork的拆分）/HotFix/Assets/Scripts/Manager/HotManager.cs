using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace HotFix
{
    public class HotManager : BaseClass
    {
        string updateWord = "";
        float updatePercent = 0;
        public List<string> downLoadFiles = new List<string>();

        public void Init()
        {
            CheckExtractResource();
        }

        void CheckExtractResource()
        {
            bool isExists = Directory.Exists(Util.DataPath) && Directory.Exists(Util.DataPath + "lua/") && File.Exists(Util.DataPath + "files.txt");
            if(isExists || AppConst.DebugMode)
            {
                StartCoroutine(OnUpdateResource());
                return;
            }

            StartCoroutine(OnExtractResource());
        }

        IEnumerator OnUpdateResource()
        {
            downLoadFiles.Clear();
            if(!AppConst.UpdateMode)
            {
                Debug.LogError("!AppConst.UpdateMode");
                Initialize(OnResourceInited);
                yield break;
            }

            string url = AppConst.WebUrl;

            string random = DateTime.Now.ToString("yyyymmddhhmmss");

            string dataUrl = url + "files.txt?v=" + random;

            WWW www = new WWW(dataUrl);

            updateWord = "版本检测中：           " + (www.progress * 100).ToString() + "%";
            updatePercent = www.progress;
            DownPanel.SetProgressAndFile(updatePercent, updateWord);
            yield return www;
            if (www.error != null)
            {
                OnUpdateFailed(www.error);
                yield break;
            }

            string dataPath = Util.DataPath;
            if (!Directory.Exists(dataPath))
                Directory.CreateDirectory(dataPath);

            File.WriteAllBytes(dataPath + "files.txt" , www.bytes);
            string filesText = www.text;
            string[] files = filesText.Split('\n');


            bool isCheckVer = false;
            string message = string.Empty;
            string strVerUrl = "";
            string strLocalVer = "";
            bool isCanUpdateVer = false;


            for(int i = 0;i < files.Length;i++)
            {
                if (string.IsNullOrEmpty(files[i]))
                    continue;

                string[] keyValue = files[i].Split('|');
                string f = keyValue[0];
                string localFile = (dataPath + f).Trim();
                string path = Path.GetDirectoryName(localFile);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileUrl = url + keyValue[0] + "?v=" + random;
                bool canUpdate = !File.Exists(localFile);
                bool isVerFile = false;

                isVerFile = f.Equals("version.txt");
                if(!canUpdate)
                {
                    string remoteMD5 = keyValue[1].Trim();
                    string localMD5 = Util.MD5File(localFile);
                    canUpdate = !remoteMD5.Equals(localMD5);
                    if (canUpdate)
                        File.Delete(localFile);

                    if(!isCheckVer && isVerFile)
                    {
                        isCheckVer = isVerFile;

                        if(isCheckVer && !canUpdate)
                        {
                            message = "更新检测完毕";
                            updateWord = message;
                            updatePercent = 1;
                            DownPanel.SetProgressAndFile(updatePercent, updateWord);

                            OnUpdateMessageComplete(message);
                            //开始初始化
                            Initialize(OnResourceInited);
                        }
                    }
                }


                if(isVerFile)
                {
                    strVerUrl = fileUrl;
                    strLocalVer = localFile;
                    isCanUpdateVer = canUpdate;
                }

                if(canUpdate && !isVerFile)
                {
                    message = "downloading>>>" + fileUrl;
                    OnUpdateMessageDownLoad(message);
                    BeginDownload(fileUrl, localFile);
                    while (!(IsDownOk(localFile)))
                    {
                        updatePercent = (float) i/files.Length;
                        updateWord = "更新游戏  " + i.ToString() + "/" + files.Length.ToString() +
                                     "                                " + Math.Ceiling(updatePercent*100) + "%";
                        DownPanel.SetProgressAndFile(updatePercent, updateWord);
                        yield return new WaitForEndOfFrame();
                    }
                }
            }

            if (isCanUpdateVer)
            {
                BeginDownload(strVerUrl, strLocalVer);
                while (!(IsDownOk(strLocalVer)))
                    yield return new WaitForEndOfFrame();
            }

            updatePercent = 100f;
            updateWord = "更新游戏         " + files.Length.ToString() + "/" + files.Length.ToString() +
                         "                                100%";
            DownPanel.SetProgressAndFile(updatePercent, updateWord);
            yield return new WaitForEndOfFrame();
            Debug.LogError("更新完成!!!!!");

            Initialize(OnResourceInited);
        }

        IEnumerator OnExtractResource()
        {
            string dataPath = Util.DataPath;
            string resPath = Util.AppContentPath();

            if (Directory.Exists(dataPath))
                Directory.Delete(dataPath, true);

            Directory.CreateDirectory(dataPath);

            string infile = resPath + "files.txt";
            string outfile = dataPath + "files.txt";

            if (File.Exists(outfile))
                File.Delete(outfile);

            string message = "正在解包文件：>files.txt";


            if (Application.platform == RuntimePlatform.Android)
            {
                WWW www = new WWW(infile);
                updateWord = "版本检测中   " + (www.progress*100).ToString() + "%";
                updatePercent = www.progress;
                DownPanel.SetProgressAndFile(updatePercent, updateWord);
                yield return www;

                if (www.isDone)
                    File.WriteAllBytes(outfile, www.bytes);

                yield return 0;
            }
            else
            {
                File.Copy(infile, outfile, true);
            }

            yield return new WaitForEndOfFrame();

            string[] files = File.ReadAllLines(outfile);
            int index = 0;
            foreach (var file in files)
            {
                index++;
                string[] fs = file.Split('|');
                infile = resPath + fs[0];
                outfile = dataPath + fs[0];

                message = "正在解包文件:>" + fs[0];


                string dir = Path.GetDirectoryName(outfile);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                if (Application.platform == RuntimePlatform.Android)
                {
                    WWW www = new WWW(infile);
                    yield return www;

                    if (www.isDone)
                        File.WriteAllBytes(outfile, www.bytes);

                    yield return 0;
                }
                else
                {
                    if (File.Exists(outfile))
                        File.Delete(outfile);

                    File.Copy(infile, outfile, true);
                }

                updatePercent = (float) index/files.Length;
                updateWord = "解压文件中          " + Math.Ceiling((updatePercent*100)) + "%";
                DownPanel.SetProgressAndFile(updatePercent, updateWord);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(0.1f);

            StartCoroutine(OnUpdateResource());
        }

        void OnUpdateFailed(string file)
        {
            string message = "更新失败：=======================<" + file + ">";
            Debug.LogError(message);
            return;
        }

        void OnUpdateMessageComplete(string message)
        {
            
            Debug.LogError(message);
            return;
        }
            
        void OnUpdateMessageDownLoad(string file)
        {
            string message = "更新下载：=======================<" + file + ">";
            Debug.LogError(message);
            return;
        }
        
        void BeginDownload(string url,string file)
        {
            object[] param = new object[2] { url, file };
            ThreadEvent ev = new ThreadEvent();
            ev.key = NotiConst.UPDATE_DOWNLOAD;
            ev.evParams.AddRange(param);
            ThreadManager.AddEvent(ev, OnThreadCompleted);
        }

        void OnThreadCompleted(NotiData data)
        {
            switch (data.evName)
            {
                case NotiConst.UPDATE_EXTRACT:
                    break;
                case NotiConst.UPDATE_DOWNLOAD:
                    if (!downLoadFiles.Contains(data.evParam.ToString()))
                        downLoadFiles.Add(data.evParam.ToString());
                    break;
            }
        }

        bool IsDownOk(string file)
        {
            return downLoadFiles.Contains(file);
        }
        
        void Initialize(Action func)
        {
            if (func != null)
                func();
        }

        void OnResourceInited()
        {
            LuaManager.InitStart();
            LuaManager.DoFile("Main.lua");

            Util.CallMethod("Main", "Start");
        }


    }
}
