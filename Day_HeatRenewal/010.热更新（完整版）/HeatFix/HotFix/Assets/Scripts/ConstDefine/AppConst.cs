using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotFix
{
    public class AppConst
    {
        //程序名称
        public const string AppName = "HotFix";
        //资源扩展名
        public const string BundleName = ".assetbundle";
        //临时目录
        public const string LuaTempDir = "LuaTempDir/";

        //!调试模式-用于内部测试
        public static bool DebugMode = true;

        //lua代码Assetbundle模式
        public static bool LuaBunldeMode = true;

        //Lua字节码模式
        public static bool LuaByteMode = false;

        //根目录
        public static string HotFixRoot = Application.dataPath + "/";
    }
}

