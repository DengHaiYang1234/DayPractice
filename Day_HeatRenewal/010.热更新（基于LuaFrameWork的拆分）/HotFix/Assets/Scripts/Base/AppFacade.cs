using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
