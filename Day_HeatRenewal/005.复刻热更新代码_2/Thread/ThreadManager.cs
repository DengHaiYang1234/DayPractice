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
		private Action<NotiData> func;
		private Stopwatch sw = new Stopwatch();
		ThreadManager tm = new ThreadManager();
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
			if (this.func != null) func(data);
			UnityEngine.Debug.Log("OnSyncEvent  OnSyncEvent!");
		}

		public void AddEvnet(ThreadEvent ev,Action<NotiData> func)
		{
			lock (m_lockObj)
			{
				this.func = func;
				events.Enqueue(ev);
			}
		}

		void OnUpdate()
		{
			while(true)
			{
				lock(m_lockObj)
				{
					if(events.Count > 0)
					{
						ThreadEvent e = events.Dequeue();
						try
						{
							switch(e.key)
							{
								case NotiConst.UPDATE_EXTRACT:
									{
										OnExtractFile(e.evParams);
									}
									break;
								case NotiConst.UPDATE_DOWNLOAD:
									{
										OnDownloadFile(e.evParams);
									}
									break;
							}
						}
						catch(System.Exception ex)
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
			UnityEngine.Debug.Log("Thread evParams: >> " + evParams.Count);
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
				client.DownloadDataAsync(new System.Uri(url), currDownFile);
			}
		}

		private void ProgressChanged(object sender,DownloadProgressChangedEventArgs e)
		{
			string value = string.Format("{0}kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
			NotiData data = new NotiData(NotiConst.UPDATE_PROGRESS, value);
			if (m_SyncEvent != null) m_SyncEvent(data);

			if(e.ProgressPercentage == 100 && e.BytesReceived == e.TotalBytesToReceive)
			{
				sw.Reset();

				data = new NotiData(NotiConst.UPDATE_DOWNLOAD, currDownFile);
				if (m_SyncEvent != null) m_SyncEvent(data);
			}
		}

	}
}

