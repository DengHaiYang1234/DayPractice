using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 启动入口
/// </summary>
public class Main : MonoBehaviour
{
	void Start ()
	{
	    AppFacade.Instance.StartUp();
	}
	

}
