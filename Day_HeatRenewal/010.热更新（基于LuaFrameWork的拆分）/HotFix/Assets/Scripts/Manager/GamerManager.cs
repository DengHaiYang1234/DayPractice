using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HotFix;

public class GamerManager : MonoBehaviour
{
    private void Awake()
    {
        AppFacade.Instance.AddManager<ThreadManager>(ManagersName.thread);
        AppFacade.Instance.AddManager<LuaManager>(ManagersName.lua);
        AppFacade.Instance.AddManager<HotManager>(ManagersName.hot);
    }

}
