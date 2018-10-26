using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HotFix;
public class BaseClass : MonoBehaviour
{
    private ThreadManager m_ThreadMgr;
    private LuaManager m_LuaMgr;
    private HotManager m_hotFixMgr;
    private GamerManager m_GameMgr;

    Facade facde = new Facade();

    public ThreadManager ThreadManager
    {
        get
        {
            if (m_ThreadMgr == null)
                m_ThreadMgr = facde.GetManager<ThreadManager>(ManagersName.thread);
            return m_ThreadMgr;
        }
    }

    public LuaManager LuaManager
    {
        get
        {
            if (m_LuaMgr == null)
                m_LuaMgr = facde.GetManager<LuaManager>(ManagersName.lua);
            return m_LuaMgr;
        }
    }

    public HotManager HotManager
    {
        get
        {
            if (m_hotFixMgr == null)
                m_hotFixMgr = facde.GetManager<HotManager>(ManagersName.hot);
            return m_hotFixMgr;
        }
    }


}
