﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorStates : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Debug.Log(anim.GetBool("isRunning"));
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
