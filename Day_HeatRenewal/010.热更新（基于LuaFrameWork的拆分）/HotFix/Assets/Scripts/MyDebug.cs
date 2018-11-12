using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MyDebug : MonoBehaviour
{
    private Vector2 ScrollPos = Vector2.zero;
    public static List<string> messages = new List<string>();
    public static List<string> names = new List<string>();
    public static bool isShow = true;
    private Text debugLog;
    //private Thread thread;
    private static Queue<string> queue = new Queue<string>();
    
    private Button closeBtn;
    private Button openBtn;

    private void Awake()
    {
        debugLog = transform.Find("Debug/Viewport/Content/Debug_Text").gameObject.GetComponent<Text>();
        closeBtn = transform.Find("Btn_Close").gameObject.GetComponent<Button>();
        openBtn = transform.Find("Btn_Open").gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        closeBtn.onClick.AddListener(Close);
        openBtn.onClick.AddListener(Open);
    }

    private void Update()
    {
        if (queue.Count > 0)
        {
            var text = debugLog.text;
            var currText = queue.Dequeue();
            debugLog.text = text + "\n" + currText;
        }
    }

    public static void Add(string name, string message = null)
    {
        queue.Enqueue(name);
    }

    void Open()
    {
        transform.Find("Debug").gameObject.SetActive(true);
    }

    void Close()
    {
        transform.Find("Debug").gameObject.SetActive(false);
    }

    //public static void Add(string name, string message)
    //{
    //    Debug.LogError("=======================name=======name:" + name);
    //    if (names.Contains(name) == false)
    //    {
    //        names.Add(name);
    //        messages.Add(message);
    //    }
    //    else
    //    {
    //        for (int i = 0; i < names.Count; i++)
    //        {
    //            if (names[i] == name)
    //            {
    //                messages[i] = message;
    //                break;
    //            }
    //        }
    //    }
    //}
    //void OnGUI()
    //{
    //    if (!isShow) return;

    //    //Debug.Log("OnGUI  OnGUI  OnGUI");

    //    #region GUI ScrollView
    //    ScrollPos = GUI.BeginScrollView(new Rect(0, 30, Screen.width, Screen.height),
    //        ScrollPos, new Rect(0, 0, 10000000000, 10000));


    //    float posY = 0;
    //    for (int i = 0; i < names.Count; i++)
    //    {
    //        GUIContent tempContent = new GUIContent();
    //        tempContent.text = names[i] + " : " + messages[i];
    //        GUIStyle bb = new GUIStyle();
    //        bb.fixedWidth = Screen.width;
    //        bb.wordWrap = true;
    //        bb.fontSize = 20 * (Screen.width / 720);
    //        float H = bb.CalcHeight(tempContent, 600 * (Screen.width / 720));
    //        GUI.Label(new Rect(0, posY, 600 * (Screen.width / 720), H), tempContent, bb);
    //        posY += H;
    //        //GUILayout.Space(10);
    //    }

    //    GUI.EndScrollView();
    //    #endregion
    //}
}
