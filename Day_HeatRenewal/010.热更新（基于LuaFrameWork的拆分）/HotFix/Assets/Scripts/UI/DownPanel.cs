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


    private static DownPanel _instance;

    public static DownPanel Instance
    {
        get
        {
            if (_instance == null)
                _instance = new DownPanel();
            return _instance;
        }
    }


    void Start ()
    {
        progress = this.transform.Find("DownPro").gameObject;
        file = this.transform.Find("DownName").gameObject;

        progressValue = progress.GetComponent<Text>();
        fileName = file.GetComponent<Text>();
    }


    public static void SetProgressAndFile(float pro,string name)
    {
        progressValue.text = pro.ToString();
        fileName.text = name;
    }


}
