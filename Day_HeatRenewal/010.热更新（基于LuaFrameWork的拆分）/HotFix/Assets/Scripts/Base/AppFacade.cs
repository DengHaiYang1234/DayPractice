using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HotFix;

/// <summary>
/// Facade单利
/// </summary>
public class AppFacade : Facade
{
    private static AppFacade _instance;

    public static AppFacade Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AppFacade();
            return _instance;
        }
    }

    public void StartUp()
    {
        AddManager<ThreadManager>(ManagersName.thread);
        AddManager<LuaManager>(ManagersName.lua);
        AddManager<HotManager>(ManagersName.hot);
        AddManager<GamerManager>(ManagersName.game);
    }

}
