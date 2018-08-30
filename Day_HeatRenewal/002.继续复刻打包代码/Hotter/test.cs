using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	void Start ()
	{
		string st = "a123";
		for(int i = 0;i < st.Length;i++)
		{
			string a = System.Convert.ToString(st[i], 16);
			Debug.Log(a);
		}

	}
	

}
