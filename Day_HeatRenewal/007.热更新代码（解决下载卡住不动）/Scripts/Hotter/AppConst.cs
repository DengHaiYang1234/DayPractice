using UnityEngine;
using System.Collections;

namespace LuaFramework
{
	public class AppConst
	{
		//应用程序名称
		public const string AppName = "HGame";

		//游戏帧率
		public const int GameFrameRate = 30;

		//资源扩展名
		public const string ExtName = ".assetbundle";

		//临时目录
		public const string LuaTempDir = "Lua/";

		//!调试模式-用于内部测试
		public static bool DebugMode = false;

		//!lua代码Assetbundle模式-默认关闭
		public static bool LuaBundleMode = true;

		//Lua字节码模式-默认关闭
		public static bool LuaByteMode = true;

		//更新模式
		public static bool UpdateMode = false;


		public static string WebUrl = "http://localhost:8081/StreamingAssets/";

		//根目录
		public static string FrameworkRoot = Application.dataPath + "/" + AppName;

	}
}

