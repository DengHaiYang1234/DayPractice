using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaFramework;

public class Base : MonoBehaviour {

	private ThreadManager m_ThreadMgr;
    private UpdateManager m_UpdateMgr;


	Facade facde = new Facade();
	

	public ThreadManager ThreadManager
	{
		get
		{
			if(m_ThreadMgr == null)
			{
				m_ThreadMgr = facde.GetManager<ThreadManager>("ThreadManager");
			}
			return m_ThreadMgr;
		}
	}

    public UpdateManager UpdateManager
    {
        get
        {
            if(m_UpdateMgr == null)
            {
                m_UpdateMgr = facde.GetManager<UpdateManager>("UpdateManager");
            }
            return m_UpdateMgr;
        }
    }



}
