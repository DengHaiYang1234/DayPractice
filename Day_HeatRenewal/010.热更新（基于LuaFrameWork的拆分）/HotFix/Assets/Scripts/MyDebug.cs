using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDebug : MonoBehaviour
{
    private Vector2 ScrollPos = Vector2.zero;
    public static List<string> messages = new List<string>();
    public static List<string> names = new List<string>();
    public static bool isShow = true;

    void OnGUI()
    {
        if (!isShow) return;

        ScrollPos = GUI.BeginScrollView(new Rect(0, 30, Screen.width, Screen.height),
            ScrollPos, new Rect(0, 0, 10000000000, 10000));


        float posY = 0;
        for (int i = 0; i < names.Count; i++)
        {
            GUIContent tempContent = new GUIContent();
            tempContent.text = names[i] + " : " + messages[i];
            GUIStyle bb = new GUIStyle();
            bb.fixedWidth = Screen.width;
            bb.wordWrap = true;
            bb.fontSize = 20 * (Screen.width / 720);
            float H = bb.CalcHeight(tempContent, 600 * (Screen.width / 720));
            GUI.Label(new Rect(0, posY, 600 * (Screen.width / 720), H), tempContent, bb);
            posY += H;
            //GUILayout.Space(10);
        }

        GUI.EndScrollView();

    }

    public static void Add(string name, string message)
    {
        if (names.Contains(name) == false)
        {
            names.Add(name);
            messages.Add(message);
        }
        else
        {
            for (int i = 0; i < names.Count; i++)
            {
                if (names[i] == name)
                {
                    messages[i] = message;
                    break;
                }
            }
        }
    }
}
