using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using LuaFramework;
using System.Diagnostics;

public class Packager : MonoBehaviour
{
	public static string platform = string.Empty;
	static List<string> paths = new List<string>();  //路径
	static List<string> files = new List<string>();  //文件
	static List<AssetBundleBuild> maps = new List<AssetBundleBuild>();
	
	static string[] exts = { ".txt", ".xml", ".lua", ".assetbundle", ".json" };

	static bool CanCopy(string ext)
	{
		foreach (var e in exts)
			if (ext.Equals(e))
				return true;
		return false;
	}

	/// <summary>
	/// 数据目录
	/// </summary>
	static string AppDataPath
	{
		get { return Application.dataPath.ToLower(); }
	}
	
	/// <summary>
	/// 载入素材
	/// </summary>
	/// <param name="file"></param>
	/// <returns></returns>
	static Object LoadAsset(string file)
	{
		return AssetDatabase.LoadMainAssetAtPath("Assets/" + file);
	}

	//[MenuItem("AssetBundle/Build iPhone Resoure",false,100)]
	//public static void BuildiPhoneResoure()
	//{
	//	BuildTarget target;
	//#if UNITY_5
	//	target = BuildTarget.iOS;
	//#else
	//	target = BuildTarget.iPhone;
	//#endif

	//}

	//[MenuItem("AssetBundle/Build Android Resoure",false,101)]
	//public static void BuildAndroidResoure()
	//{

	//}

	[MenuItem("AssetBundle/Build Windows Resoure",false,102)]
	public static void BuildWindowsResoure()
	{
		BuildAssetResource(BuildTarget.StandaloneWindows, false);
	}

	public static void BuildAssetResource(BuildTarget target,bool delfold = true)
	{
		if (Directory.Exists(Util.DataPath) && delfold)
			Directory.Delete(Util.DataPath, true);
		string streamPath = Application.streamingAssetsPath;
		if (Directory.Exists(streamPath) && delfold)
			Directory.Delete(streamPath, true);

		AssetDatabase.Refresh();

		if (AppConst.LuaBundleMode)
			HandleBundle();
		else
			//这一步的作用是将游戏资源目录中的lua及Tolua文件资源全部拷贝至SteamingAssets中去.
			HandleLuaFile();  

		GenerateVersion();
		BuildFileIndex();
		AssetDatabase.Refresh();

	}
	
	static void HandleBundle()
	{
		BuildLuaBundles();
		string luaPath = AppDataPath + "/StreamingAssets/lua/";
		string[] luaPaths = {AppDataPath + "/" + AppConst.AppName + "/lua/",
			AppDataPath + "/" + AppConst.AppName + "/Tolua/Lua/"
		};

		for(int i =0;i < luaPaths.Length;i++)
		{
			paths.Clear();
			files.Clear();
			string luaDataPath = luaPaths[i].ToLower();
			Recursive(luaDataPath);
			int n = 0;
			foreach(string f in files)
			{
				if(f.EndsWith(".meta"))
				{
					continue;
				}

				string newFile = f.Replace(luaDataPath, "");
				string newPath = luaPath + newFile;
				string path = Path.GetDirectoryName(newPath);
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
				if (File.Exists(newPath))
					File.Delete(newPath);
				//if(AppConst.LuaByteMode)
				//{
				//	EncodeLuaFile(f, newPath);
				//}
				//else
				//{
				//	File.Copy(f, newPath, true);
				//}
				File.Copy(f, newPath, true);
				UpdateProgress(n++, files.Count, newPath);
			}
		}
		EditorUtility.ClearProgressBar();
		AssetDatabase.Refresh();
	}

	static void BuildLuaBundles()
	{
		ClearAllLuaFiles();
		CreateStreamDir("lua/");  
		CreateStreamDir(AppConst.LuaTempDir); 

		string dir = Application.persistentDataPath;
		if (!File.Exists(dir))
			Directory.CreateDirectory(dir);


		string streamDir = Application.dataPath + "/" + AppConst.LuaTempDir;  //临时目录
		CopyLuaBytesFiles(CustomSettings.luaDir, streamDir);  // 将CustomSettings.luaDir中的所有lua文件添加.bytes拷贝至streamDir目录中
		CopyLuaBytesFiles(CustomSettings.FrameworkPath + "/Tolua/Lua", streamDir);

		AssetDatabase.Refresh();
		string[] dirs = Directory.GetDirectories(streamDir, "*", SearchOption.AllDirectories);//通配符通配符*和?分别 *代表的是所有字符（不限个数） ？代表的是所有字符（只限一个)
		for (int i =0;i < dirs.Length;i++)
		{
			string str = dirs[i].Remove(0, streamDir.Length);
			BuildLuaBundle(str);
		}

		BuildLuaBundle(null);
		Directory.Delete(streamDir, true);
		AssetDatabase.Refresh();                                                                                         
	}

	static void ClearAllLuaFiles()
	{
		string osPath = Application.streamingAssetsPath + "/" + LuaConst.osDir;

		if(Directory.Exists(osPath))
		{
			string[] files = Directory.GetFiles(osPath, "Lua*" + AppConst.ExtName);
			for(int i = 0;i < files.Length;i++)
			{
				File.Delete(files[i]);
			}
		}


		string path = osPath + "/Lua";

		if (Directory.Exists(path))
			Directory.Delete(path, true);

		path = Application.dataPath + "/Resources/Lua";

		if (Directory.Exists(path))
			Directory.Delete(path, true);

		path = Application.persistentDataPath + "/" + LuaConst.osDir + "/Lua";

		if (Directory.Exists(path))
			Directory.Delete(path, true);
	}

	static void CreateStreamDir(string dir)
	{
		dir = Application.streamingAssetsPath + "/" + dir;

		if (!File.Exists(dir))
			Directory.CreateDirectory(dir);
	}

	static void CopyLuaBytesFiles(string sourceDir,string destDir,bool appendext = true)
	{
		if (!Directory.Exists(sourceDir))
			return;

		string[] files = Directory.GetFiles(sourceDir, "*.lua", SearchOption.AllDirectories);
		int len = sourceDir.Length;

		if(sourceDir[ len - 1] == '/' || sourceDir[len - 1] == '\\')
		{
			--len;
		}

		for(int i = 0;i < files.Length;i++)
		{
			string str = files[i].Remove(0, len);
			string dest = destDir + str;
			if (appendext)
				dest += ".bytes";
			string dir = Path.GetDirectoryName(dest);
			Directory.CreateDirectory(dir);
			File.Copy(files[i], dest, true);
		}
	}

	static void EncodeLuaFile(string srcFile,string outFile)
	{
		if(!srcFile.ToLower().EndsWith(".lua"))
		{
			File.Copy(srcFile, outFile, true);
			return;
		}

		bool isWin = true;
		string luaexe = string.Empty;
		string args = string.Empty;
		string exedir = string.Empty;
		string currDir = Directory.GetCurrentDirectory();
		if(Application.platform == RuntimePlatform.WindowsEditor) //windows Unity Editor
		{
			isWin = true;
			luaexe = "luajit.exe";
			args = "-b" + srcFile + "" + outFile;
			exedir = AppDataPath.Replace("assets", "") + "LuaEncoder/luajit/";
		}
		else if(Application.platform == RuntimePlatform.OSXEditor)
		{
			isWin = false;
			luaexe = "./luac";
			args = "-o" + outFile + " " + srcFile;
			exedir = AppDataPath.Replace("assets", "") + "LuaEncoder/luavm/";
		}

		Directory.SetCurrentDirectory(exedir);

		ProcessStartInfo info = new ProcessStartInfo();
		info.FileName = luaexe;
		info.Arguments = args;
		info.WindowStyle = ProcessWindowStyle.Hidden;
		info.UseShellExecute = isWin;
		info.ErrorDialog = true;
		Util.Log(info.FileName + " " + info.Arguments);

		Process pro = Process.Start(info);
		pro.WaitForExit();
		Directory.SetCurrentDirectory(currDir);
	}

	static void BuildLuaBundle(string dir)
	{
		maps.Clear();
		BuildAssetBundleOptions options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets |
											BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.UncompressedAssetBundle;
		string path = "Assets/" + AppConst.LuaTempDir + dir;
		string[] files = Directory.GetFiles(path, "*.lua.bytes");
		AssetBundleBuild[] abbs = new AssetBundleBuild[files.Length];
		
		List<Object> list = new List<Object>();
		string bundleName = "lua" + AppConst.ExtName;
		if(dir != null)
		{
			dir = dir.Replace('\\', '_').Replace('/', '_');
			if(dir.EndsWith("lpeg") || dir.EndsWith("protobuf") || dir.EndsWith("socket"))
			{
				return;
			}

			bundleName = "lua_" + dir.ToLower() + AppConst.ExtName;
		}

		#region--------------使用BuildAssetBundle方法打包-------------- -
		//for (int i = 0; i < files.Length; i++)
		//{
		//	Object obj = AssetDatabase.LoadMainAssetAtPath(files[i]);
		//	list.Add(obj);
		//}

		//if (files.Length > 0)
		//{
		//	string output = Application.streamingAssetsPath + "/lua/" + bundleName;
		//	if (File.Exists(output))
		//		File.Delete(output);

		//	BuildPipeline.BuildAssetBundle(null, list.ToArray(), output, options, EditorUserBuildSettings.activeBuildTarget);
		//	AssetDatabase.Refresh();
		//}
		#endregion

		#region ------------------使用BuildAssetBundles方法--------------
		AssetBundleBuild build = new AssetBundleBuild();
		build.assetBundleName = bundleName;
		build.assetNames = files;
		maps.Add(build);

		if (files.Length > 0)
		{
			string output = Application.streamingAssetsPath + "/lua/"  ;
			if (File.Exists(output))
				File.Delete(output);
			
			BuildPipeline.BuildAssetBundles(output, maps.ToArray(), options, EditorUserBuildSettings.activeBuildTarget);
			AssetDatabase.Refresh();
		}
		//-------------------------------------------------------
		#endregion
	}

	static void Recursive(string path)
	{
		string[] names = Directory.GetFiles(path);
		string[] dirs = Directory.GetDirectories(path);
		foreach(string filename in names)
		{
			string ext = Path.GetExtension(filename);
			if (ext.Equals(".meta"))
				continue;
			files.Add(filename.Replace('\\', '/'));
		}

		foreach(string dir in dirs)
		{
			if (dir.EndsWith(".svn") || dir.EndsWith(".svn\\") || dir.EndsWith(".svn/"))
				continue;
			paths.Add(dir.Replace('\\', '/'));
			Recursive(dir);
		}
	}

	static void UpdateProgress(int progress,int progressMax,string desc)
	{
		string title = "Procressing .. [" + progress + " - " + progressMax + "]";
		float value = (float)progress / (float)progressMax;
		EditorUtility.DisplayProgressBar(title, desc, value);
	}

	static void HandleLuaFile()
	{
		string luaPath = AppDataPath + "/StreamingAssets/lua";

		if (!Directory.Exists(luaPath))
			Directory.CreateDirectory(luaPath);
		string[] luaPaths = { AppDataPath + "/" + AppConst.AppName + "/lua",
			AppDataPath + "/" + AppConst.AppName + "/Tolua/Lua"
		};

		for(int i = 0; i< luaPaths.Length;i++)
		{
			paths.Clear();
			files.Clear();
			string luaDataPath = luaPaths[i].ToLower();
			Recursive(luaDataPath);
			int n = 0;
			foreach(string f in files)
			{
				if (f.EndsWith(".meta"))
					continue;
				string newFile = f.Replace(luaDataPath, "");
				string newPath = luaPath + newFile;
				string path = Path.GetDirectoryName(newPath);
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
				if (File.Exists(newPath))
					File.Delete(newPath);

				File.Copy(f, newPath, true);
				//if (AppConst.LuaByteMode)
				//	//EncodeLuaFile(f, newPath);
				//else
					
				UpdateProgress(n++, files.Count, newPath);
			}
		}

		EditorUtility.ClearProgressBar();
		AssetDatabase.Refresh();

	}

	static void GenerateVersion()
	{
		string resPath = AppDataPath + "/StreamingAssets/";
		string versionPath = resPath + "/version.txt";
		if (File.Exists(versionPath))
			File.Delete(versionPath);

		FileStream fs = new FileStream(versionPath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		string currentTime = System.DateTime.Now.ToString("yyyymmddhhmmss");
		sw.WriteLine(currentTime);
		sw.Close();
		fs.Close();
	}

	static void BuildFileIndex()
	{
		string resPath = AppDataPath + "/StreamingAssets/";
		string newFilePath = resPath + "/files.txt";
		if (File.Exists(newFilePath))
			File.Delete(newFilePath);
		paths.Clear();
		files.Clear();
		Recursive(resPath);

		FileStream fs = new FileStream(newFilePath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		for(int i = 0;i < files.Count;i++)
		{
			string file = files[i];
			Path.GetExtension(file);
			if (file.EndsWith(".meta") || file.Contains(".DS_Store") || file.EndsWith(".manifest"))
				continue;

			string md5 = Util.md5file(file);
			string value = file.Replace(resPath, string.Empty);
			sw.WriteLine(value + "|" + md5);
		}
		sw.Close();
		fs.Close();
	}






}
