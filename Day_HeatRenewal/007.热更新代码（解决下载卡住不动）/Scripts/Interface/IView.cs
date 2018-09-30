using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView
{
	void OnMessage(IMessage message);
}
