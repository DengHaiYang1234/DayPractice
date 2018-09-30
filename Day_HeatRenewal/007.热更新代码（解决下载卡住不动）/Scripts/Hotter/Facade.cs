using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facade 
{
	static GameObject m_GameManager;
	static Dictionary<string, object> m_Managers = new Dictionary<string, object>();

	GameObject AppGameManager
	{
		get {
			if(m_GameManager == null)
			{
				m_GameManager = GameObject.Find("GameManager");
			}
			return m_GameManager;
		}
	}

	
	public T AddManager<T>(string typeName) where T : Component
	{
		object result = null;
        m_Managers.TryGetValue(typeName, out result);
        if (result != null)
		{
            return (T)result;
		}
        Component c = AppGameManager.AddComponent<T>();
        m_Managers.Add(typeName,c);
        return default(T);
	}


	public T GetManager<T>(string typeName) where T :class
	{
		if(!m_Managers.ContainsKey(typeName))
		{
			return default(T);
		}

		object manager = null;
		m_Managers.TryGetValue(typeName, out manager);
		return (T)manager;
	}


}
