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
        HotManager_.Init();
    }


    public void StartGame(Action func = null)
    {
        Util.LogErr("GamerManager  GamerManager  StartGame");
    }


    #endregion
}
