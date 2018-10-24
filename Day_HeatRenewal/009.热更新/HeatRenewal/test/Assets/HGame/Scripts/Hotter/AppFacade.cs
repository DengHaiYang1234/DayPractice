using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppFacade : Facade {

	private static AppFacade _instacnce;

	public static AppFacade Instance
	{
		get
		{
			if(_instacnce == null)
			{
				_instacnce = new AppFacade();
			}
			return _instacnce;
		}
	}
}
