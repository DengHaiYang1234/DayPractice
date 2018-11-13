using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HotFix;
using System;

public class GamerManager : BaseClass
{
    #region 游戏管理类
    public void Awake()
    {
        SDRootPath.Instance.Init();
        HotManager_.Init();
    }


    private void Start()
    {
        if (LTDebugOutput.Instance != null)
        {
            LTDebugOutput.Instance.Init();
        }
    }


    #endregion
}
