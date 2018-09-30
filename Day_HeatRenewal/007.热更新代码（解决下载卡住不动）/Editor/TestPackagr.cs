using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using LuaFramework;

public class TestPackagr : MonoBehaviour
{
	static List<string> paths = new List<string>();
	static List<string> files = new List<string>();
	static List<AssetBundleBuild> maps = new List<AssetBundleBuild>();

	static string AppDataPath
	{
		get { return Application.dataPath.ToLower(); }
	}

	[MenuItem("AssetBundle/Build Test Windows Resoure",false,102)]
	public static void BuildWindowResourse()
	{
		BuildAssetResource(BuildTarget.StandaloneWindows, false);
	}

	public static void BuildAssetResource(BuildTarget target,bool defold = true)
	{
		if(Directory.Exists(Util.DataPath) && defold)
		{
			Directory.Delete(Util.DataPath,true);
		}

		string streamPath = Application.streamingAssetsPath;  

		if (Directory.Exists(streamPath) && defold)
			Directory.Delete(streamPath, true);

		AssetDatabase.Refresh();
		if (AppConst.LuaBundleMode)
			HandleBundle();
		else
			HandleLuaFile();
	}

	static void HandleBundle()
	{
		BuildLuaBundles();
		string luapath = AppDataPath + "/StreamingAssets/lua/";
		string[] luaPaths = {
			AppDataPath + "/" + AppConst.AppName + "/lua/",
			AppDataPath + "/" + AppConst.AppName + "/Tolua/Lua"
		};

		for(int i = 0;i < luaPaths.Length;i++)
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
				string newPath = luapath + newFile;
				string path = Path.GetDirectoryName(newPath);
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
				if (File.Exists(newPath))
					File.Delete(newPath);
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

		//-----------将项目中的lua及tolua文件全部转换成.bytes文件并拷贝至临时lua目录---------------
		string streamDir = Application.dataPath + "/" + AppConst.LuaTempDir; //临时lua存放目录
		CopyLuaBytesFiles(CustomSettings.luaDir, streamDir);
		CopyLuaBytesFiles(CustomSettings.FrameworkPath + "/Tolua/Lua", streamDir);
		//----------------------------------------------------------------------------------


		AssetDatabase.Refresh();
		string[] dirs = Directory.GetDirectories(streamDir, "*", SearchOption.AllDirectories);
		for(int i =0;i < dirs.Length;i++)
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

		if (sourceDir[len - 1] == '/' || sourceDir[len - 1] == '\\')
			len--;

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
	
	static void HandleLuaFile()
	{
		//stream目录
		string luaPath = AppDataPath + "/StreamingAssets/lua";

		if (!Directory.Exists(luaPath))
			Directory.CreateDirectory(luaPath);
		//工程中的lua及tolua目录
		string[] luaPaths =
		{
			AppDataPath + "/" + AppConst.AppName + "/lua",
			AppDataPath + "/" + AppConst.AppName + "/ToLua/Lua"
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

				UpdateProgress(n++, files.Count, newPath);
			}
		}

		EditorUtility.ClearProgressBar();
		AssetDatabase.Refresh();
	}

	static void BuildLuaBundle(string dir)
	{
		BuildAssetBundleOptions options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets |
											BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.UncompressedAssetBundle;

		string path = "Assets/" + AppConst.LuaTempDir + dir;
		string[] files = Directory.GetFiles(path, "*.lua.bytes");

		List<Object> list = new List<Object>();
		string bundleName = "lua" + AppConst.ExtName;
		if(dir != null)
		{
			dir = dir.Replace('\\', '_').Replace('/', '_');
			if (dir.EndsWith("lpeg") || dir.EndsWith("protobuf") || dir.EndsWith("socket"))
				return;
			bundleName = "lua_" + dir.ToLower() + AppConst.ExtName;
		}

		for(int i = 0;i < files.Length;i++)
		{
			Object obj = AssetDatabase.LoadMainAssetAtPath(files[i]);
			list.Add(obj);
		}

		AssetBundleBuild build = new AssetBundleBuild();
		build.assetBundleName = bundleName;
		build.assetNames = files;
		maps.Add(build);


		
		if(files.Length > 0)
		{
			string output = Application.streamingAssetsPath + "/lua/" + bundleName;
			if (File.Exists(output))
				File.Delete(output);
			BuildPipeline.BuildAssetBundles(output, maps.ToArray(), options, EditorUserBuildSettings.activeBuildTarget);
			//BuildPipeline.BuildAssetBundle(null, list.ToArray(), output, options, EditorUserBuildSettings.activeBuildTarget);
			AssetDatabase.Refresh();
		}
	}

	static void Recursive(string path)
	{
		string[] names = Directory.GetFiles(path);
		string[] dirs = Directory.GetDirectories(path);
		foreach(string fileName in names)
		{
			string ext = Path.GetExtension(fileName);
			if (ext.Equals(".meta"))
				continue;
			files.Add(fileName.Replace('\\', '/'));
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

}
