using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotiData
{
	public string evName;
	public object evParam;

	public NotiData(string name,object param)
	{
		this.evName = name;
		this.evParam = param;
	}

}
