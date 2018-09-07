using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LuaFramework;
using System;
using LuaInterface;

public class UpdateManager : Base
{
	bool initialize = false;
	string tipStr = "";
	string[] tipStrs =
	{
		"游戏第一次安装...................",
		"耐心等待.............."
	};

	List<string> downloadFiles = new List<string>();
	string updateWord = "";
	float updatePercent = 0;
	void Awake()
	{
		AppFacade.Instance.AddManager<ThreadManager>("ThreadManager");
		Init();
	}
	
	void Init()
	{
		StartCoroutine(RandomShowStr());
		CheckExtractResource();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Application.targetFrameRate = AppConst.GameFrameRate;
	}

	IEnumerator RandomShowStr()
	{
		while(!initialize)
		{
			tipStr = tipStrs[UnityEngine.Random.Range(0, tipStrs.Length)];
			yield return new WaitForSeconds(3.0f);
		}
		yield return new WaitForEndOfFrame();
	}

	public void CheckExtractResource()
	{
		bool isExists = Directory.Exists(Util.DataPath) && Directory.Exists(Util.DataPath + "lua/") && File.Exists(Util.DataPath + "files.txt");
		if (isExists || AppConst.DebugMode)
		{
			StartCoroutine(OnUpdateResource());
			return;
		}
		StartCoroutine(OnExtractResource());
	}

	IEnumerator OnUpdateResource()
	{
		downloadFiles.Clear();

		if(!AppConst.UpdateMode)
		{
			Debug.LogError("调试模式不需要更新");
			Initialize(OnResourceInited);
			yield break;
		}
		Debug.LogError("开始下载更新");
		string url = AppConst.WebUrl;
		//if (Application.platform == RuntimePlatform.IPhonePlayer)
		//	url += "ios/";
		//else
		//	url += "android/";
		string random = DateTime.Now.ToString("yyyymmddhhmmss");
		string listUrl = url + "files.txt?v=" + random;

		WWW www = new WWW(listUrl);
		updateWord = "版本检测中:      " + (www.progress * 100).ToString() + "%";
		Debug.LogError(updateWord);
		updatePercent = www.progress;
		Debug.LogError(updatePercent + "%");
		yield return www;

		if(www.error != null)
		{
			OnUpdateFailed(string.Empty);
			yield break;
		}

		string dataPath = Util.DataPath;
		if (!Directory.Exists(dataPath))
			Directory.CreateDirectory(dataPath);

		File.WriteAllBytes(dataPath + "files.txt", www.bytes);
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
				string remoteMd5 = keyValue[1].Trim();
				string localMd5 = Util.md5file(localFile);
				canUpdate = !remoteMd5.Equals(localMd5);
				if (canUpdate)
					File.Delete(localFile);

				if (!isCheckVer && isVerFile)
				{
					isCheckVer = isVerFile;

					if(isCheckVer && !canUpdate)
					{
						message = "更新检测完成";

						updateWord = message;
						updatePercent = 1;

						OnUpdateMessageComplete(message);
						Initialize(OnResourceInited);
						yield break;
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
				message = "downloading>>" + fileUrl;
				Debug.LogError(updateWord);
				OnUpdateMessageComplete(message);
				BeginDownload(fileUrl, localFile);
				while(!(IsDownOK(localFile)))
				{
					updatePercent = (float)i / files.Length;
					updateWord = "更新游戏   " + i.ToString() + "/" + files.Length.ToString() +
						"                                       " + Math.Ceiling((updatePercent * 100)) + "%";

					Debug.LogError(updateWord);

					yield return new WaitForEndOfFrame(); 
				}
			}
		}

		if(isCanUpdateVer)
		{
			BeginDownload(strVerUrl, strLocalVer);
			while (!(IsDownOK(strLocalVer)))
				yield return new WaitForEndOfFrame();
		}
		updatePercent = 100.0f;
		updateWord = "更新游戏       " + files.Length.ToString() + "/" + files.Length.ToString() +
			"                                         100%";
		Debug.LogError(updateWord);
		yield return new WaitForEndOfFrame();
		message = "更新完成";


		updateWord = message;
		Debug.LogError(updateWord);
		updatePercent = 1;

		Debug.Log(NotiConst.UPDATE_MESSAGE);

		Initialize(OnResourceInited);
	}

	IEnumerator OnExtractResource()
	{
		string dataPath = Util.DataPath;
		string resPath = Util.AppContentPath();

		if(Directory.Exists(dataPath))
		{
			Directory.Delete(dataPath, true);
		}

		Directory.CreateDirectory(dataPath);

		string infile = resPath + "files.txt";
		string outfile = dataPath + "files.txt";

		if (File.Exists(outfile))
			File.Delete(outfile);

		string message = "正在解包文件：>files.txt";

		Debug.Log(NotiConst.UPDATE_MESSAGE);

		if(Application.platform == RuntimePlatform.Android)
		{
			WWW www = new WWW(infile);
			updateWord = "版本检测中    " + (www.progress * 100).ToString() + "%";
			updatePercent = www.progress;

			yield return www;

			if(www.isDone)
			{
				File.WriteAllBytes(outfile, www.bytes);
			}
			yield return 0;
		}
		else
		{
			File.Copy(infile, outfile, true);
		}

		yield return new WaitForEndOfFrame();

		string[] files = File.ReadAllLines(outfile);
		int index = 0;
		foreach(var file in files)
		{
			index++;
			string[] fs = file.Split('|');
			infile = resPath + fs[0];
			outfile = dataPath + fs[0];

			message = "正在解包文件:>" + fs[0];
			Debug.Log("正在解包文件:>" + infile);
			Debug.Log(NotiConst.UPDATE_MESSAGE);

			string dir = Path.GetDirectoryName(outfile);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			if(Application.platform == RuntimePlatform.Android)
			{
				WWW www = new WWW(infile);
				yield return www;

				if(www.isDone)
				{
					File.WriteAllBytes(outfile, www.bytes);
				}

				yield return 0;
			}
			else
			{
				if (File.Exists(outfile))
					File.Delete(outfile);

				File.Copy(infile, outfile, true);
			}

			updatePercent = (float)index / files.Length;
			updateWord = "解压文件中      " + Math.Ceiling((updatePercent * 100)) + "%";
			yield return new WaitForEndOfFrame();
		}
		Debug.Log(NotiConst.UPDATE_MESSAGE + "更新完成");

		yield return new WaitForSeconds(0.1f);

		StartCoroutine(OnUpdateResource());

	}

	void Initialize(Action func)
	{
		Console.WriteLine("初始化资源...........");
		if (func != null)
			func();
	}

	void OnResourceInited()
	{
		LuaState lua = new LuaState();
		lua.Start();
		lua.DoFile(LuaConst.luaDir + "/Main.lua");
		Console.WriteLine("资源初始化完成.....下一步......");
	}

	void OnUpdateFailed(string file)
	{
		string message = "更新失败！>" + file;
		Debug.Log(message);
		return;
	}

	void OnUpdateMessageComplete(string file)
	{
		string message = "更新完成！>" + file;
		Debug.Log(message);
		return;
	}

	void BeginDownload(string url,string file)
	{
		object[] param = new object[2] { url, file };
		ThreadEvent ev = new ThreadEvent();
		ev.key = NotiConst.UPDATE_DOWNLOAD;
		ev.evParams.AddRange(param);
		ThreadManager.AddEvnet(ev,OnThreadCompleted);
	}

	void OnThreadCompleted(NotiData data)
	{
		Debug.LogWarning("OnThreadCompleted  OnThreadCompleted :" + data.evName);
		switch (data.evName)
		{
			case NotiConst.UPDATE_EXTRACT:
				break;
			case NotiConst.UPDATE_DOWNLOAD:
				downloadFiles.Add(data.evParam.ToString());
				break;
		}
	}

	bool IsDownOK(string file)
	{
		return downloadFiles.Contains(file);
	}


}
