using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _ani;

    private int speedID = Animator.StringToHash("Speed");
    private int isSpeedUpID = Animator.StringToHash("IsSpeedUp");
    private int horizontalID = Animator.StringToHash("Horizontal");

    private void Start()
    {
        _ani = GetComponent<Animator>();
    }

    void Update()
    {
        _ani.SetFloat(speedID, Input.GetAxis("Vertical"));
        _ani.SetFloat(horizontalID, Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _ani.SetBool(isSpeedUpID, true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _ani.SetBool(isSpeedUpID, false);
        }
    }

}
