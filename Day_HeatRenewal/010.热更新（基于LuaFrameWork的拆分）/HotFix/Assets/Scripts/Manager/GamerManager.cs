using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HotFix;



public class GamerManager : BaseClass
{
    #region 游戏管理类
    private void Awake()
    {
        HotManager.Init();
    }
    #endregion
}
