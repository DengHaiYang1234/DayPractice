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
        public static List<string> downLoadFiles = new List<string>();

        void Init()
        {

        }

        void CheckExtractResource()
        {
            bool isExists = Directory.Exists(Util.DataPath) && Directory.Exists(Util.DataPath + "lua/") && File.Exists(Util.DataPath + "files.txt");
            if(isExists || AppConst.DebugMode)
            {

            }
        }

        IEnumerator OnUpdateResource()
        {
            downLoadFiles.Clear();
            if(!AppConst.UpdateMode)
            {
                Initialize(OnResourceInited);
                yield break;
            }

            string url = AppConst.WebUrl;

            string random = DateTime.Now.ToString("yyyymmddhhmmss");

            string dataUrl = url + "files.txt?v=" + random;

            WWW www = new WWW(dataUrl);

            updateWord = "版本检测中：           " + (www.progress * 100).ToString() + "%";
            updatePercent = www.progress;
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
                    
                }
            }

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

        }


        void Initialize(Action func)
        {
            if (func != null)
                func();
        }

        void OnResourceInited()
        {

        }

    }
}
