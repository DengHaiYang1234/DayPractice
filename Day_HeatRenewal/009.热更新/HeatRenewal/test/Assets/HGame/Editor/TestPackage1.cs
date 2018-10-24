using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using LuaFramework;
using System.Diagnostics;

public class TestPackage1 
{
	static List<string> paths = new List<string>();
	static List<string> files = new List<string>();
	static List<AssetBundleBuild> maps = new List<AssetBundleBuild>();

	static string AppDataPath
	{
		get { return Application.dataPath.ToLower(); }
	}

	[MenuItem("AssetBundle/Build Test1 Windows Resource",false,110)]
	public static void BuildWindowsResource()
	{
		BuildAssetResource(BuildTarget.StandaloneWindows,false);
	}

	public static void BuildAssetResource(BuildTarget target,bool delfold = true)
	{
		if (Directory.Exists(Util.DataPath) && delfold)
			Directory.Delete(Util.DataPath, true);
		string streamPath = Application.streamingAssetsPath;
		if (Directory.Exists(streamPath) && delfold)
			Directory.Delete(streamPath,true);

		AssetDatabase.Refresh();
		if (AppConst.LuaBundleMode)
			HandleBundle();
		else
			HandleLuaFile();  //拷贝资源文件至数据目录

		GenerateVersion();
		BuildFileIndex();
		AssetDatabase.Refresh();
	}

	/// <summary>
	/// lua文件打包入口
	/// </summary>
	static void HandleBundle()
	{
		BuildLuaAssetsBundles();
		string luaPath = AppDataPath + "/StreamingAssets/lua/";
		string[] luaPaths = {
			AppDataPath + "/" + AppConst.AppName + "/Lua/",
			AppDataPath + "/" + AppConst.AppName + "/Tolua/Lua"
		};

		CopyLuaFiles(luaPath, luaPaths);
	}

	/// <summary>
	/// 将资源目录中的lua及Tolua文件打包至数据目录中
	/// </summary>
	static void BuildLuaAssetsBundles()
	{
		ClearAllLuaFiles();
		CreatStreamDir("lua/");
		CreatStreamDir(AppConst.LuaTempDir);

		string dir = Application.persistentDataPath; //可读写目录
		if (!Directory.Exists(dir))
			Directory.CreateDirectory(dir);

		string streamDir = Application.dataPath + "/" + AppConst.LuaTempDir;
		CopyLuaBytesFiles(CustomSettings.luaDir, streamDir);  //将资源目录中的lua文件拷贝至数据目录
		string workPath = Application.dataPath + "/" + AppConst.AppName;
		CopyLuaBytesFiles(workPath + "/Tolua/Lua", streamDir);//将资源目录中的ToLua文件拷贝至数据目录

		AssetDatabase.Refresh();
		string[] dirs = Directory.GetDirectories(streamDir, "*", SearchOption.AllDirectories); //匹配所有文件夹
		for(int i = 0;i < dirs.Length;i++)
		{
			string str = dirs[i].Remove(0, streamDir.Length);
			BuildLuaBundle(str);  //打包lua文件夹下的目录资源
		}

		BuildLuaBundle(null);//打包lua文件夹下的资源
		Directory.Delete(streamDir, true); //删除临时目录
		AssetDatabase.Refresh();
	}

	/// <summary>
	/// 清除数据目录中已存在的lua或Tolua文件
	/// </summary>
	static void ClearAllLuaFiles()
	{
		string osPath = Application.streamingAssetsPath + "/" + LuaConst.osDir;

		if(Directory.Exists(osPath))
		{
			string[] files = Directory.GetFiles(osPath, "Lua*" + AppConst.ExtName);
			for (int i = 0; i < files.Length; i++)
				File.Delete(files[i]);
		}

		string path = osPath + "/Lua";
		if (Directory.Exists(path))
			Directory.Delete(path, true);

		path = Application.dataPath + "Resources/Lua";
		if (Directory.Exists(path))
			Directory.Delete(path, true);

		path = Application.persistentDataPath + "/" + LuaConst.osDir + "/Lua";
		if (Directory.Exists(path))
			Directory.Delete(path);
	}

	/// <summary>
	/// 在数据目录中创建数据文件
	/// </summary>
	/// <param name="dir"></param>
	static void CreatStreamDir(string dir)
	{
		dir = Application.streamingAssetsPath + "/" + dir;

		if (!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
	}

	/// <summary>
	/// 将源文件夹中的文件转换为bytes文件全部拷贝至目标文件夹中
	/// </summary>
	/// <param name="sourceDir"></param>  源文件夹
	/// <param name="destDir"></param>   目标文件夹
	/// <param name="appendext"></param>
	static void CopyLuaBytesFiles(string sourceDir,string destDir,bool appendext = true)
	{
		if (!Directory.Exists(sourceDir))
			return;
		//匹配源文件夹下所有的lua文件
		string[] _files = Directory.GetFiles(sourceDir, "*.lua", SearchOption.AllDirectories);
		int len = sourceDir.Length;

		if(sourceDir[len - 1] == '/' || sourceDir[len - 1] == '\\')
		{
			len--;
		}

		for(int i = 0;i < _files.Length;i++)
		{
			string str = _files[i].Remove(0, len);  //相对路径的文件名
			string dest = destDir + str;  //新文件路径（绝对路径）
			if (appendext)
				dest += ".bytes";  //转换为bytes文件
			string dir = Path.GetDirectoryName(dest);
			Directory.CreateDirectory(dir);  //保持与源文件夹一直的存储方式

            if(AppConst.LuaByteMode)
            {
                EncodeLuaFile(_files[i], dest);
            }
            else
            {
                File.Copy(_files[i], dest, true);
            }

			
		}
	}

	/// <summary>
	/// 打包资源。将文件夹下的所有文件打成一个AB包
	/// </summary>
	/// <param name="dir"></param>  指定文件夹(相对路径)
	static void BuildLuaBundle(string dir)
	{
		maps.Clear();

		BuildAssetBundleOptions options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets
											| BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.UncompressedAssetBundle;

		string path = "Assets/" + AppConst.LuaTempDir + dir;   //临时资源路径（相对路径）
		string[] _files = Directory.GetFiles(path, "*.lua.bytes");
		AssetBundleBuild build = new AssetBundleBuild(); //新打包方式
		List<Object> list = new List<Object>(); //旧打包方式
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

		#region--------------使用BuildAssetBundle方法打包---------------
		//for(int i = 0; i < _files.Length;i++)
		//{
		//	Object obj = AssetDatabase.LoadMainAssetAtPath(files[i]);
		//	list.Add(obj);
		//}

		//if(_files.Length > 0)
		//{
		//	string output = Application.streamingAssetsPath + "/lua/" + bundleName;
		//	if (File.Exists(output))
		//		File.Delete(output);

		//	BuildPipeline.BuildAssetBundle(null, list.ToArray(), output, options, EditorUserBuildSettings.activeBuildTarget);
		//	AssetDatabase.Refresh();
		//}
		#endregion

		#region ------------------使用BuildAssetBundles方法--------------
		build.assetBundleName = bundleName;
		build.assetNames = _files;
		maps.Add(build);

		if(_files.Length > 0)
		{
			string output = Application.streamingAssetsPath + "/lua/";
			if (File.Exists(output))
				File.Delete(output);

			BuildPipeline.BuildAssetBundles(output, maps.ToArray(), options, EditorUserBuildSettings.activeBuildTarget);
			AssetDatabase.Refresh();
		}
		#endregion
	}

	/// <summary>
	/// 将资源目录中的lua及Tolua资源拷贝至数据目录(StraemAssets)中
	/// </summary>
	static void HandleLuaFile()
	{
		string luaPath = AppDataPath + "/StreamingAssets/lua";  //数据目录

		if (!Directory.Exists(luaPath))
			Directory.CreateDirectory(luaPath);

		string[] luaPaths = {
			AppDataPath + "/" + AppConst.AppName + "/lua", //lua资源目录
			AppDataPath + "/" + AppConst.AppName + "/Tolua/Lua" //Tolua资源目录
		};

		CopyLuaFiles(luaPath,luaPaths);
	}

	/// <summary>
	/// 得到当前路径下的所有文件及文件夹
	/// </summary>
	/// <param name="path"></param>
	static void Recursive(string path)
	{
		string[] _files = Directory.GetFiles(path); //获取路径下所有文件
		string[] dirs = Directory.GetDirectories(path);//获取路径下所有文件夹
		foreach(string filename in _files)//filename 文件名(绝对路径)
		{
			string ext = Path.GetExtension(filename); //获取文件后缀名
			if (ext.Equals(".meta"))
				continue;
			files.Add(filename.Replace('\\', '/')); //保存文件
		}

		foreach(string dir in dirs) //dir 文件夹名(绝对路径)
		{
			if (dir.EndsWith(".svn") || dir.EndsWith(".svn\\") || dir.EndsWith(".svn/"))
				continue;
			paths.Add(dir.Replace('\\', '/')); //保存文件夹名
			Recursive(dir);
		}
	}

	/// <summary>
	/// 进度显示
	/// </summary>
	/// <param name="progress"></param>
	/// <param name="progressMax"></param>
	/// <param name="desc"></param>
	static void UpdateProgress(int progress,int progressMax,string desc)
	{
		string title = "Progressing .. [" + progress + " - " + progressMax + "]";
		float value = (float)progress / (float)progressMax;
		EditorUtility.DisplayProgressBar(title, desc, value);
	}

	/// <summary>
	/// 从源文件夹拷贝至目标文件夹
	/// </summary>
	/// <param name="destDir"></param>
	/// <param name="sourcesDirs"></param>
	static void CopyLuaFiles(string destDir,string[] sourcesDirs)
	{
		for (int i = 0; i < sourcesDirs.Length; i++)
		{
			paths.Clear();
			files.Clear();

			string luaDataPath = sourcesDirs[i].ToLower();
			Recursive(luaDataPath);
			int n = 0;
			foreach (string f in files)
			{
				if (f.EndsWith(".meta"))
					continue;
				string newFile = f.Replace(luaDataPath, "");//得到文件名的相对路径
				string newPath = destDir + newFile; //在数据目录中的文件路径
				string path = Path.GetDirectoryName(newPath);//获取文件路径的文件夹
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);

				if (File.Exists(newPath))  //删除原有文件
					File.Delete(newPath);

                if(AppConst.LuaByteMode)
                {
                    EncodeLuaFile(f, newPath);
                }
                else
                {
                    File.Copy(f, newPath, true);  //开始拷贝文件
                }
                
				UpdateProgress(n++, files.Count, newPath);
			}
		}
		EditorUtility.ClearProgressBar();
		AssetDatabase.Refresh();
	}

	/// <summary>
	/// 创建版本文件
	/// </summary>
	static void GenerateVersion()
	{
		string resPath = AppDataPath + "/StreamingAssets/";
		string versionPath = resPath + "/version.txt";
		if (File.Exists(versionPath))
			File.Delete(versionPath); //删除原有的版本文件

		FileStream fs = new FileStream(versionPath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		string currentTime = System.DateTime.Now.ToString("yyyymmddhhmmss");
		sw.WriteLine(currentTime);
		sw.Close();
		fs.Close();
	}

	/// <summary>
	/// 将已有的ab包资源名和对应的文件md5写入txt文件
	/// </summary>
	static void BuildFileIndex()
	{
		string resPath = AppDataPath + "/StreamingAssets/";
		string newFilePath = resPath + "/files.txt";
		if (File.Exists(newFilePath))
			File.Delete(newFilePath);

		paths.Clear();
		files.Clear();
		Recursive(resPath);   //获取数据目录的所有资源路径

		FileStream fs = new FileStream(newFilePath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		for(int i = 0; i < files.Count;i++)
		{
			string file = files[i];
			Path.GetExtension(file);
			if(file.EndsWith(".meta") || file.EndsWith(".manifest"))
			{
				continue;
			}

			string md5 = Util.md5file(file);  //获取文件md5码
			string value = file.Replace(resPath, string.Empty);
			sw.WriteLine(value + "|" + md5); //将文件的相对路径及md5码保存起来。以便热更新比对
		}
		sw.Close();
		fs.Close();
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
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            isWin = true;
            luaexe = "luajit.exe";
            args = "-b" + srcFile + " " + outFile;
            exedir = AppDataPath.Replace("assets", "") + "LuaEncoder/luajit/";
        }
        else if(Application.platform == RuntimePlatform.OSXEditor)
        {
            isWin = false;
            luaexe = "./luac";
            args = "-o " + outFile + " " + srcFile;
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
}
