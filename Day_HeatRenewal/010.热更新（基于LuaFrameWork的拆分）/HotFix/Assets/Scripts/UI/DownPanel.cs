using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HotFix
{
    public class DownPanel : MonoBehaviour
    {
        GameObject progress;
        GameObject file;

        static Text progressValue;
        static Text fileName;
        
        public static void SetProgressValue(string str)
        {
            if (progressValue == null)
            {
                GameObject panel = GetObj();
                progressValue = panel.transform.Find("Canvas/DownPro").gameObject.GetComponent<Text>();

                progressValue.text = str;
            }
            
        }

        public static void SetFileValue(string str)
        {
            if (fileName == null)
            {
                GameObject panel = GetObj();

                if (panel.transform.Find("Canvas/DownName") != null)
                {
                    fileName = panel.transform.Find("Canvas/DownName").gameObject.GetComponent<Text>();

                    fileName.text = str;
                }
                else
                {
                    Util.LogErr("不存在 fileName  fileName  fileName！！！！！！");
                }
            }
        }

        public static GameObject GetObj()
        {
            GameObject panel = GameObject.Find("DownLoadPanel(Clone)") as GameObject;
            return panel;
        }
    }
}

