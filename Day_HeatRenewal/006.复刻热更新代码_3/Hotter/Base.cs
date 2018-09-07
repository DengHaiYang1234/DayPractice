using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaFramework;

public class Base : MonoBehaviour {

	private ThreadManager m_ThreadMgr;

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

}
