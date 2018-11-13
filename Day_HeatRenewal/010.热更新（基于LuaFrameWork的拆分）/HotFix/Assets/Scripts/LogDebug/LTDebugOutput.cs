using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HotFix;
using System.IO;

public class LTDebugOutput : MonoBehaviour
{
    public class LogData
    {
        public Color TextColor;
        public string Condition;
        public string StackTrace;
    }

    private bool _ShowDebugPanel = false;
    
    private bool _hasInit = false;
    private string _outPutPath = null;
    private List<LogData> _printDebugTxt = new List<LogData>();



    public static LTDebugOutput Instance;
    [HeaderAttribute("Debug ScrollView Panel")]
    public GameObject m_LogPanel;
    [HeaderAttribute("Debug根节点")]
    public GameObject DebugRootPanel;
    [HeaderAttribute("是否开启Debug")]
    public bool isOpen = true;
    [HeaderAttribute("Debug输出Compent")]
    public LTDebugText m_LogPrefab;
    [HeaderAttribute("开启线程接收")]
    public bool ThreadRecrive = false;
    public bool isLoging = true;

    private void Awake()
    {
        Instance = this;

        UnityEngine.Debug.logger.filterLogType = LogType.Log;
        Application.logMessageReceived += Application_LogMessageReceived;
        Application.logMessageReceivedThreaded += Application_LogMessageReceivedThread;

        if (Application.platform == RuntimePlatform.WindowsEditor) CloseLog();

    }

    public void Init()
    {
        _hasInit = true;
        string binRootPath = SDRootPath.Instance.GetBinFileRootPath();
        if (!Directory.Exists(binRootPath))
            Directory.CreateDirectory(binRootPath);

        string logPath = SDRootPath.Instance.GetLogFolderPath();
        if (!Directory.Exists(logPath))
            Directory.CreateDirectory(logPath);

        _outPutPath = SDRootPath.Instance.GetCurLogFilePath();
        if (Directory.Exists(SDRootPath.Instance.GetBinFileRootPath()))
        {
            if (File.Exists(_outPutPath))
                File.Delete(_outPutPath);
        }
        else
        {
            Directory.CreateDirectory(SDRootPath.Instance.GetBinFileRootPath());
        }

        SDDebug.Init(_outPutPath);

    }

    private void Update()
    {
        lock (_printDebugTxt)
        {
            var cnt = Mathf.Min(_printDebugTxt.Count, 10);
            for (int i = 0; i < cnt; i++)
            {
                LogData data = _printDebugTxt[i];
                AddLine(data.Condition, data.StackTrace, data.TextColor);
            }
            _printDebugTxt.RemoveRange(0, cnt);
        }
    }

    private void Application_LogMessageReceived(string condition,string stackTrace,LogType type)
    {
        if (!isOpen) return;

        if (!m_LogPanel.gameObject.activeSelf) m_LogPanel.SetActive(true);

        if (!isLoging) return;

        switch (type)
        {
            case LogType.Log:
                AddLine("[I]" + condition, stackTrace, Color.green);
                break;
            case LogType.Warning:
                //AddLine("[W]" + condition, stackTrace, Color.yellow);
                break;
            case LogType.Assert:
                AddLine("[A]" + condition, stackTrace, Color.black);
                break;
            case LogType.Error:
                AddLine("[E]" + condition, stackTrace, Color.red);
                break;
            case LogType.Exception:
                AddLine("[X]" + condition, stackTrace, Color.magenta);
                break;

        }
    }

    private void Application_LogMessageReceivedThread(string condition, string stackTrace, LogType type)
    {
        if (!ThreadRecrive) return;

        if (!isLoging) return;

        switch (type)
        {
            case LogType.Log:
                AddLine("[I]" + condition, stackTrace, Color.green);
                break;
            case LogType.Warning:
                //AddLine("[W]" + condition, stackTrace, Color.yellow);
                break;
            case LogType.Assert:
                AddLine("[A]" + condition, stackTrace, Color.black);
                break;
            case LogType.Error:
                AddLine("[E]" + condition, stackTrace, Color.red);
                break;
            case LogType.Exception:
                AddLine("[X]" + condition, stackTrace, Color.magenta);
                break;
        }
    }

    void CloseLog()
    {
        if (m_LogPanel.gameObject.activeSelf)
            m_LogPanel.SetActive(false);
    }

    void UpdateDebugPanelShow()
    {
        DebugRootPanel.SetActive(_ShowDebugPanel);
    }


    private void AddLine(string msg, string stackTrace, Color color)
    {
        m_LogPrefab.m_Text.color = color;
        m_LogPrefab.m_Text.text = msg;
        m_LogPrefab.condition = msg;
        m_LogPrefab.stackTrace = stackTrace;

        GameObject tempObj = GameObject.Instantiate(m_LogPrefab.gameObject);
        tempObj.transform.SetParent(m_LogPrefab.transform.parent, false);
        tempObj.SetActive(true);
    }

}
