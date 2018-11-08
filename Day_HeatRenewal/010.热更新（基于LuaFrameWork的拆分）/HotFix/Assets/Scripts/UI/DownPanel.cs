using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownPanel : MonoBehaviour
{
    GameObject progress;
    GameObject file;

    static Text progressValue;
    static Text fileName;


    void Start ()
    {
        progress = this.transform.Find("DownPro").gameObject;
        file = this.transform.Find("DownName").gameObject;

        progressValue = progress.GetComponent<Text>();
        fileName = file.GetComponent<Text>();

        SetProgressAndFile();
    }


    public static void SetProgressAndFile()
    {
        progressValue.text = "下载已全部完成！！！！！   测试";
        fileName.text = "文件已全部下载完成   测试";
    }


}
