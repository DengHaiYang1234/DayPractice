using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TestDownLoad : MonoBehaviour
{
    WebClient client = new WebClient();
    string url = "http://localhost:8081/StreamingAssets/lua/Build.bat?v=20185029045038";
    //string currDownFile = "d:/hgame/lua/Build.bat";
    string currDownFile = "d:/hgame/Build.bat";
    void Start()
    {
        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
        client.DownloadFileAsync(new System.Uri(url), currDownFile);
    }
    void DownloadProgressCallback(object sender,DownloadProgressChangedEventArgs e)
    {
        var str = string.Format("{0}       downloaded{1} of {2} bytes. {3} % complete...",
            (string)e.UserState,
        e.BytesReceived,
        e.TotalBytesToReceive,
        e.ProgressPercentage);

        Debug.LogError(str);

    }
}
