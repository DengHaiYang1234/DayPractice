using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : IController
{
	protected IDictionary<string, Type> m_commandMap;
	protected IDictionary<IView, List<string>> m_viewCmdMap;

	//volatile提醒编译器它后面所定义的变量随时都有可能改变，因此编译后的程序每次需要存储或读取这个变量的时候，
	//都会直接从变量地址中读取数据。如果没有volatile关键字，则编译器可能优化读取和存储，可能暂时使用寄存器中的值，如果这个变量由别的程序更新了的话，将出现不一致的现象。
	protected static volatile IController m_instance;
	protected readonly object m_syncRoot = new object();
	protected static readonly object m_staticSyncRoot = new object();


	public static IController Instance
	{
		get
		{
			if(m_instance == null)
			{
				lock(m_staticSyncRoot)
				{
					if(m_instance == null)
					{
						m_instance = new Controller();
					}
				}
			}
			return m_instance;
		}
	}

	public void ExecuteCommand(IMessage note)
	{
		Type commandType = null;
		List<IView> views = null;
		lock(m_syncRoot)
		{
			if (m_commandMap.ContainsKey(note.Name))
				commandType = m_commandMap[note.Name];
			else
			{
				views = new List<IView>();
				foreach(var de in m_viewCmdMap)
				{
					if(de.Value.Contains(note.Name))
					{
						views.Add(de.Key);
					}
				}
			}
				

		}
	}

	public bool HasCommand(string messageName)
	{
		throw new NotImplementedException();
	}

	public void RegisterCommand(string messageName, Type commandType)
	{
		throw new NotImplementedException();
	}

	public void RegisterViewCommand(IView view, string[] commandNames)
	{
		throw new NotImplementedException();
	}

	public void RemoveCommand(string messageName)
	{
		throw new NotImplementedException();
	}

	public void RemoveViewCommand(IView view, string[] commandNames)
	{
		throw new NotImplementedException();
	}
}
