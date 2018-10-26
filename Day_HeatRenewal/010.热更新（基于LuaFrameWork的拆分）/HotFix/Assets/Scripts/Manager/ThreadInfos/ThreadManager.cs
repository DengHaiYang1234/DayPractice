using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

namespace HotFix
{
    public class NotiData
    {
        public string evName;
        public object evParam;

        public NotiData(string name,object param)
        {
            this.evName = name;
            this.evParam = param;
        }
    }


    public class ThreadManager : MonoBehaviour
    {
        private Thread thrad;
        private Action<NotiData> func;
        private Stopwatch sw = new Stopwatch();

        private string currDownFile = string.Empty;

        private static readonly object m_lockObj = new object();

        private static Queue<ThreadEvent> events = new Queue<ThreadEvent>();

        private delegate void ThreadSyncEvent(NotiData data);

        private ThreadSyncEvent m_SyncEvent;

        private void Awake()
        {
            thrad.Start();
        }

    }
}


