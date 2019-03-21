using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Biker : MonoBehaviour
{

    private Animator _ani;

	// Use this for initialization
	void Start ()
	{
	    _ani = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    int value =  (int)Input.GetAxisRaw("Vertical");
        _ani.SetInteger("Vertical", value);
	    //transform.Translate(transform.forward * value * Time.deltaTime * 4f);
	}
}
