using UnityEngine;
using System.Collections;
using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace LuaFramework
{
	public class Util
	{
		public static int Int(object o)
		{
			return Convert.ToInt32(o);
		}

		public static float Float(object o)
		{
			//将双精度浮点值按指定的小数位舍入.
			return (float)Math.Round(Convert.ToSingle(o), 2); //Math.Round ： 四舍六入五取偶
		}

		public static long Long(object o)
		{
			return Convert.ToInt64(o);
		} 

		public static int Random(int min,int max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static float Random(float min,float max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static string Uid(string uid)
		{
			int position = uid.LastIndexOf('_');
			return uid.Remove(0, position + 1);
		}

		public static long GetTime()
		{
			TimeSpan ts = new TimeSpan(DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0,0).Ticks);//将 TimeSpan 结构的新实例初始化为指定的刻度数。
			return (long)ts.TotalMilliseconds;//获取以整毫秒数和毫秒的小数部分表示的当前 TimeSpan 结构的值。
		}


		/// <summary>
		///  搜索子物体组件-GameObject版
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="go"></param>
		/// <param name="subnode"></param>
		/// <returns></returns>
		public static T Get<T>(GameObject go,string subnode) where T : Component  //where T : Component.是指T类型参数是基于Component的。比如这里return 1就会报错，但return GetComponent就可以。
		{
			if (go != null)
			{
				Transform sub = go.transform.Find(subnode);
				if(sub != null)
				{
					return sub.GetComponent<T>();
				}
			}
			return null;
		}

		/// <summary>
		/// 搜索子物体组件-Transform版
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="go"></param>
		/// <param name="subonde"></param>
		/// <returns></returns>
		public static T Get<T>(Transform go,string subonde) where T : Component
		{
			if(go != null)
			{
				Transform sub = go.Find(subonde);
				if (sub != null)
					return sub.GetComponent<T>();
			}
			return null;
		}

		/// <summary>
		/// 搜索子物体组件-Component版
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="go"></param>
		/// <param name="subnode"></param>
		/// <returns></returns>
		public static T Get<T>(Component go,string subnode)
		{
			return go.transform.Find(subnode).GetComponent<T>();
		}

		/// <summary>
		/// 添加组件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="go"></param>
		/// <returns></returns>
		public static T Add<T>(GameObject go) where T : Component
		{
			if(go != null)
			{
				T[] ts = go.GetComponents<T>();
				for(int i = 0;i < ts.Length;i++)
				{
					if(ts[i] != null)
					{
						GameObject.Destroy(ts[i]);
					}
				}
				return go.gameObject.AddComponent<T>();
			}


			return null;
		}

		/// <summary>
		/// 添加组件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="go"></param>
		/// <returns></returns>
		public static T Add<T>(Transform go) where T : Component
		{
			return Add<T>(go.gameObject);
		}
		/// <summary>
		/// 查找子对象
		/// </summary>
		/// <param name="go"></param>
		/// <param name="subnode"></param>
		/// <returns></returns>
		public static GameObject Child(GameObject go,string subnode)
		{
			return Child(go.transform, subnode);
		}
		/// <summary>
		/// 查找子对象
		/// </summary>
		/// <param name="go"></param>
		/// <param name="subnode"></param>
		/// <returns></returns>
		public static GameObject Child(Transform go,string subnode)
		{
			Transform tran = go.Find(subnode);
			if (tran == null)
				return null;
			return tran.gameObject;
		}
		/// <summary>
		/// 平级对象
		/// </summary>
		/// <param name="go"></param>
		/// <param name="subnode"></param>
		/// <returns></returns>
		public static GameObject Peer(GameObject go,string subnode)
		{
			return Peer(go.transform, subnode);
		}
		/// <summary>
		/// 平级对象
		/// </summary>
		/// <param name="go"></param>
		/// <param name="subnode"></param>
		/// <returns></returns>
		public static GameObject Peer(Transform go,string subnode)
		{
			Transform tran = go.parent.Find(subnode);
			if (tran == null)
				return null;
			return tran.gameObject;
		}

		/// <summary>
		///  计算字符串的MD5值
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string md5(string source)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			byte[] data = System.Text.Encoding.UTF8.GetBytes(source);
			byte[] md5data = md5.ComputeHash(data, 0, data.Length);
			md5.Clear();

			string destString = "";
			for (int i = 0; i < md5data.Length; i++)
				//System.Convert.ToString(md5data[i], 16)  转化为16进制
				destString += System.Convert.ToString(md5data[i], 16).PadLeft(2, '0');//PadLeft  向左第二位补零(不足两位补位成两位)
			destString = destString.PadLeft(32, '0');
			return destString;
		}
		/// <summary>
		/// 计算文件MD5码
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public static string md5file(string file)
		{
			try
			{
				//FileMode.Open : 以读/写访问权限打开指定路径上的 FileStream。
				FileStream fs = new FileStream(file, FileMode.Open);
				System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] retVal = md5.ComputeHash(fs);
				fs.Close();
				//字符串一旦创建就不可修改大小，每次使用System.String类中的方法之一时，都要在内存中创建一个新的字符串对象，这就需要为该新对象分配新的空间。
				//在需要对字符串执行重复修改的情况下，与创建新的String对象相关的系统开销可能会非常昂贵。如果要修改字符串而不创建新的对象，
				//则可以使用System.Text.StringBuilder类。
				StringBuilder sb = new StringBuilder();
				for(int i =0;i < retVal.Length;i++)
				{
					sb.Append(retVal[i].ToString("x2")); //转成小写的16进制 2表示输出两位，不足的2位的前面补0,如 0x0A 如果没有2,就只会输出0xA
				}
				return sb.ToString();
			}
			catch(Exception ex)
			{
				throw new Exception("md5file{} fail,erroe:" + ex.Message);
			}
		}


		public static string DataPath
		{
			get {
				string game = AppConst.AppName.ToLower();
				if (Application.isMobilePlatform)
					return Application.persistentDataPath + "/" + game + "/";  //可读写目录
				if (Application.platform == RuntimePlatform.WindowsPlayer)
					return Application.streamingAssetsPath + "/";
				if (AppConst.DebugMode && Application.isEditor)
					return Application.streamingAssetsPath + "/";
				if (Application.platform == RuntimePlatform.OSXEditor)
				{
					int i = Application.dataPath.LastIndexOf('/');
					return Application.dataPath.Substring(0, i + 1) + game + "/";
				}
				return "d:/" + game + "/";
			}
		}


		public static string AppContentPath()
		{
			string path = string.Empty;
			switch(Application.platform)
			{
				case RuntimePlatform.Android:
					path = "jar:file://" + Application.dataPath + "!/assets/";
					break;
				case RuntimePlatform.IPhonePlayer:
					path = Application.dataPath + "/Raw/";
					break;
				default:
					path = Application.dataPath + "/StreamingAssets";
					break;
			}
			return path;
		}



		public static void Log(string str)
		{
			Debug.Log(str);
		}


		public static void LogWarning(string str)
		{
			Debug.LogWarning(str);
		}

		public static void LogError(string str)
		{
			Debug.LogError(str);
		}

	}
}

