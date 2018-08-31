using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facade 
{
	protected IController m_controller;
	static GameObject m_GameManager;
	static Dictionary<string, object> m_Manager = new Dictionary<string, object>();

	protected Facade()
	{

	}

	protected virtual void InitFramwork()
	{
		if (m_controller != null) return;
		
	}
}
