﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using System.IO;

namespace LuaFramework
{
    public class LuaLoader : LuaFileUtils
    {
        public LuaLoader()
        {
            instance = this;
            beZip = AppConst.LuaBundleMode;
        }

        /// <summary>
        /// 添加打入Lua代码的AssetBundle
        /// </summary>
        /// <param name="bundleName"></param>
        public void AddBundle(string bundleName)
        {
            if (!bundleName.EndsWith(AppConst.ExtName))
                bundleName += AppConst.ExtName;
            string url = Util.DataPath + bundleName.ToLower();
            if(File.Exists(url))
            {
                AssetBundle bundle = AssetBundle.LoadFromFile(url);
                if(bundle != null)
                {
                    bundleName = bundleName.Replace("lua/", "").Replace(AppConst.ExtName, "");
                    base.AddSearchBundle(bundleName.ToLower(), bundle);
                }
            }
        }

        /// <summary>
        /// 当luaVM加载Lua文件的时候，这里就会被调用
        /// 用户可以自定义加载行为，只要返回byte[]即可
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public override byte[] ReadFile(string fileName)
        {
            return base.ReadFile(fileName);
        }
    }
}

