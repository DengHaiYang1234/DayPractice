using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using UnityEngine;


namespace LuaFramework
{
	public class ThreadManager : MonoBehaviour
	{
		private Thread thread;
		private Action<NotiData> funcNotice;
		private Stopwatch sw = new Stopwatch();

		private string currDownFile = string.Empty;

		static readonly object m_lockObj = new object();
		static Queue<ThreadEvent> events = new Queue<ThreadEvent>();

		delegate void ThreadSyncEvent(NotiData data);
		private ThreadSyncEvent m_SyncEvent;

		void Awake()
		{
            m_SyncEvent = OnSyncEvent;
			thread = new Thread(OnUpdate);
		}

		private void Start()
		{
			thread.Start();
		}

		private void OnSyncEvent(NotiData data)
		{
            UnityEngine.Debug.LogError("Dequeue zhi hou funcNotice:" + funcNotice == null);
            UnityEngine.Debug.LogError("开始回调:" + data.evName);
            UnityEngine.Debug.LogError("开始回调1:" + this.funcNotice != null);

            if (this.funcNotice != null)
            {
                Console.WriteLine("进入回调：");
                this.funcNotice(data);
            }

            UnityEngine.Debug.LogError("回调完成  OnSyncEvent完毕");
        }

		public void AddEvnet(ThreadEvent ev,Action<NotiData> func)
		{

			lock (m_lockObj)
			{
                this.funcNotice = func;

				events.Enqueue(ev);
                UnityEngine.Debug.LogError("新一轮添加AddEvnet:" + ev.key);
                UnityEngine.Debug.LogError("新一轮添加AddEvnet:" + func == null);
            }
		}

		void OnUpdate()
		{
			while (true)
			{
				lock (m_lockObj)
				{
					if (events.Count > 0)
					{
						ThreadEvent e = events.Dequeue();
                        UnityEngine.Debug.LogError("Dequeue zhi hou funcNotice:" + funcNotice == null);
						try
						{
							switch (e.key)
							{
								case NotiConst.UPDATE_EXTRACT:
									{     //解压文件
										OnExtractFile(e.evParams);
									}
									break;
								case NotiConst.UPDATE_DOWNLOAD:
									{    //下载文件
									
										OnDownloadFile(e.evParams);
									}
                                    UnityEngine.Debug.LogError("Dequeue zhi hou funcNotice:" + funcNotice == null);
                                    break;
							}
						}
						catch (System.Exception ex)
						{
							UnityEngine.Debug.LogError(ex.Message);
						}
					}
				}
				Thread.Sleep(1);
			}
		}


		void OnExtractFile(List<object> evParams)
		{
			NotiData data = new NotiData(NotiConst.UPDATE_EXTRACT, null);
			if (m_SyncEvent != null) m_SyncEvent(data);
		}

		void OnDownloadFile(List<object> evparam)
		{
			string url = evparam[0].ToString();
            currDownFile = evparam[1].ToString();
			using (WebClient client = new WebClient())
			{
				sw.Start();
				client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
				client.DownloadFileAsync(new System.Uri(url), currDownFile);
                
            }
		}

		private void ProgressChanged(object sender,DownloadProgressChangedEventArgs e)
		{
			string value = string.Format("{0}kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
            NotiData data = new NotiData(NotiConst.UPDATE_PROGRESS, value);
            if (m_SyncEvent != null) m_SyncEvent(data);

            if (e.ProgressPercentage == 100 && e.BytesReceived == e.TotalBytesToReceive)
			{
				sw.Reset();
                data = new NotiData(NotiConst.UPDATE_DOWNLOAD, currDownFile);
                //若回调未完成.那么使用该方法即可完成回调
                UpdateManager.downloadFiles.Add(data.evParam.ToString());
                UnityEngine.Debug.LogError("下载完成  下载完成  下载完成  下载完成 进入 m_SyncEvent" + currDownFile);
                if (m_SyncEvent != null) m_SyncEvent(data);
            }
		}

		private void OnDestroy()
		{
			thread.Abort();
		}

	}
}

