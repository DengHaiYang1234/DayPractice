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
		private Action<NotiData> funcNoti;
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
			UnityEngine.Debug.LogError("void Start()  void Start() void Start()");
		}

		private void OnSyncEvent(NotiData data)
		{
			UnityEngine.Debug.Log("OnSyncEvent  OnSyncEvent:" + data.evName);
			UnityEngine.Debug.Log("OnSyncEvent  OnSyncEvent:" + data.evParam);
			if (funcNoti != null)
			{
				UnityEngine.Debug.Log("OnSyncEvent  OnSyncEvent!");
				funcNoti(data);
			}
			else
			{
				UnityEngine.Debug.Log("Fuck  Fuck  Fuck  Fuck  Fuck !" + (funcNoti == null));
			}
		}

		public void AddEvnet(ThreadEvent ev,Action<NotiData> func)
		{
			funcNoti = func;
			UnityEngine.Debug.Log("Fuck is Func Is null???????:" + (func == null));
			lock (m_lockObj)
			{
				UnityEngine.Debug.Log("Fuck is Func Is null???????:" + (func == null));
				
				UnityEngine.Debug.Log("Fuck is Func Is null???????:" + (funcNoti == null));
				UnityEngine.Debug.LogError("events.Count  events.Count  events.Count:" + events.Count);
				events.Enqueue(ev);
			}
			UnityEngine.Debug.Log("Fuck is Func Is null???????:" + (funcNoti == null));
		}

		void OnUpdate()
		{
			while(true)
			{
				lock (m_lockObj)
				{
					if(events.Count > 0)
					{
						UnityEngine.Debug.LogError("events.Count  events.Count  events.Count:" + events.Count);
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
										UnityEngine.Debug.Log("ProgressChanged  Fuck is Func Is null???????:" + (funcNoti == null));
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
			UnityEngine.Debug.Log("ProgressChanged  Fuck is Func Is null???????:" + (funcNoti == null));
			string url = evparam[0].ToString();
			currDownFile = evparam[1].ToString();
			UnityEngine.Debug.LogError("currDownFileUrl  currDownFileUrl  currDownFileUrl  currDownFileUrl:" + url);
			UnityEngine.Debug.LogError("currDownFile  currDownFile  currDownFile  currDownFile:" + currDownFile);
			using (WebClient client = new WebClient())
			{
				UnityEngine.Debug.Log("ProgressChanged  Fuck is Func Is null???????:" + (funcNoti == null));
				sw.Start();
				client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
				client.DownloadDataAsync(new System.Uri(url), currDownFile);
			}
		}

		private void ProgressChanged(object sender,DownloadProgressChangedEventArgs e)
		{
			UnityEngine.Debug.Log("ProgressChanged  Fuck is Func Is null???????:" + (funcNoti == null));
			string value = string.Format("{0}kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
			NotiData data = new NotiData(NotiConst.UPDATE_PROGRESS, value);
			UnityEngine.Debug.Log("ProgressChanged  Fuck is Func Is null???????:" + (funcNoti == null));
			if (m_SyncEvent != null) m_SyncEvent(data);

			if(e.ProgressPercentage == 100 && e.BytesReceived == e.TotalBytesToReceive)
			{
				sw.Reset();

				data = new NotiData(NotiConst.UPDATE_DOWNLOAD, currDownFile);
				if (m_SyncEvent != null) m_SyncEvent(data);
			}
		}

		private void OnDestroy()
		{
			thread.Abort();
		}

	}
}

