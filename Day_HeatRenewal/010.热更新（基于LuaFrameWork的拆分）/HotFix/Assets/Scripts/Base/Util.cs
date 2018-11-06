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
        #region  辅助方法
        /// <summary>
        /// 数据目录  注：除了在调试模式，Lua文件的加载路径都是通过DataPath
        /// </summary>
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

        public static void LogErr(string str)
        {
            Debug.LogError(str);
        }

        public static void LogWarn(string str)
        {
            Debug.LogWarning(str);
        }
        /// <summary>
        /// 编写文件的MD5校验码
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 访问lua方法
        /// </summary>
        /// <param name="module"></param>  文件名
        /// <param name="func"></param> 方法名
        /// <param name="args"></param>
        /// <returns></returns>
        public static object[] CallMethod(string module, string func, params object[] args)
        {
            LuaManager luaMgr = AppFacade.Instance.GetManager<LuaManager>(ManagersName.lua);
            if (luaMgr == null)
                return null;
            return luaMgr.CallFunction(TrimPath(module) + "." + func);
        }

        /// <summary>
        /// 截取最后一个‘/’之后的路径.  例：Main.main
        /// </summary>
        /// <param name="origName"></param>
        /// <returns></returns>
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
        #endregion
    }
}

