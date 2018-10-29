using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

namespace HotFix
{
    public class Util
    {
        public static string DataPath
        {
            get
            {
                string game = AppConst.AppName.ToLower();
                if (Application.isMobilePlatform)
                    return Application.persistentDataPath + "/" + game + "/";
                if (Application.platform == RuntimePlatform.WindowsPlayer)
                    return Application.streamingAssetsPath + "/";
                if (AppConst.DebugMode && Application.isEditor)
                    return Application.streamingAssetsPath + "/";
                if(Application.platform == RuntimePlatform.OSXEditor)
                {
                    int i = Application.dataPath.LastIndexOf("/");
                    return Application.dataPath.Substring(0, i + 1) + game + "/";
                }

                return "d:/" + game + "/";
            }
        }

        public static void Log(string str)
        {
            Debug.Log(str);
        }

        public static string MD5File(string file)
        {
            try
            {
                FileStream fs = new FileStream(file, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(fs);
                fs.Close();

                StringBuilder sb = new StringBuilder();
                for(int i = 0;i < retVal.Length;i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch(Exception ex)
            {
                throw new System.Exception("md5File{} fail,err:" + ex.Message);
            }
        }

        public static string AppContentPath()
        {
            string path = string.Empty;
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    path = "jar:file://" + Application.dataPath + "!/assets/";
                    break;
                case RuntimePlatform.IPhonePlayer:
                    path = Application.dataPath + "/Raw/";
                    break;
                default:
                    path = Application.dataPath + "/StreamingAssets/";
                    break;
            }

            return path;
        }

        public static object[] CallMethod(string module, string func, params object[] args)
        {
            LuaManager luaMgr = AppFacade.Instance.GetManager<LuaManager>(ManagersName.lua);
            if (luaMgr == null)
                return null;
            return luaMgr.CallFunction(TrimPath(module) + "." + func);
        }

        public static string TrimPath(string origName)
        {
            string fileName = origName;
            if (fileName.IndexOf('/') != -1)
            {
                fileName = fileName.Substring(fileName.LastIndexOf('/') + 1);
            }

            if (fileName.IndexOf('.') != -1)
                return fileName.Substring(0, fileName.LastIndexOf('.'));

            return fileName;
        }

    }


}

