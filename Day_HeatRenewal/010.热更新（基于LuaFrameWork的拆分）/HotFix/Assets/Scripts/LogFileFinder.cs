using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogFileFinder : MonoBehaviour
{

    public string output = "";
    public string stack = "";

    private void Awake()
    {
        gameObject.AddComponent<MyDebug>();
    }
    
    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        //错误日志
        output = logString;
        //调用堆栈
        //stack = stackTrace;
        if (type == LogType.Error)
        {
            output = "<color=#A90404FF>" + output + "</color>";
            //stack = "<color=#A90404FF>" + stack + "</color>";
        }
        else if (type == LogType.Warning)
        {
            //output = "<color=#FFD800FF>" + output + "</color>";
            //stack = "<color=#FFD800FF>" + stack + "</color>";
        }
        else
        {
            output = "<color=#FFFFFFFF>" + output + "</color>";
            //stack = "<color=#FFD800FF>" + stack + "</color>";
        }

        MyDebug.Add(output, stack);
    }
}
