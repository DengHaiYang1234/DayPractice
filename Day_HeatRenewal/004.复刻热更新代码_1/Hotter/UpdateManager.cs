using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LuaFramework;
using System;

public class UpdateManager : MonoBehaviour
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
			StartCoroutine(OnUpdateResource());
			return;
		StartCoroutine(OnExtractResource());
	}

	IEnumerator OnUpdateResource()
	{
		downloadFiles.Clear();

		if(!AppConst.UpdateMode)
		{
			Initialize(OnResourceInited);
			yield break;
		}

		string url = AppConst.WebUrl;
		if (Application.platform == RuntimePlatform.IPhonePlayer)
			url += "ios/";
		else
			url += "android/";
		string random = DateTime.Now.ToString("yyyymmddhhmmss");
		string listUrl = url + "files.txt?v=" + random;

		WWW www = new WWW(listUrl);
		updateWord = "版本检测中:      " + (www.progress * 100).ToString() + "%";
		updatePercent = www.progress;
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
				OnUpdateMessageComplete(message);

			}

		}
	

		
	}

	IEnumerator OnExtractResource()
	{

	}

	void Initialize(Action func)
	{
		Console.WriteLine("初始化资源...........");
		if (func != null)
			func();
	}

	void OnResourceInited()
	{
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


	}






}
