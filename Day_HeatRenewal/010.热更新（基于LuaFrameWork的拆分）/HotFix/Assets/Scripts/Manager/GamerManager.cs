using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HotFix;

public class GamerManager : BaseClass
{
    private void Awake()
    {
        HotManager.Init();
    }

}
