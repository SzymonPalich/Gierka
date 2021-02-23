﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float maxVelocity = 8.0f;
    [SerializeField] private float velocityDelta = 50.0f;
    private float zeroVelocity = 0.0f;
    Rigidbody2D rb2d_en;
    private bool isGrounded;

    void Start()
    {
        rb2d_en = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 1.0f),
            new Vector2(transform.position.x + 0.5f, transform.position.y - 1.05f), groundLayers);
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(rb2d_en.transform.position,GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position) < 7.5f)
        {
            Attack();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (rb2d_en.position.x > 5 && rb2d_en.velocity.x <= 0)
        {
            Debug.Log(rb2d_en.position.x);
            if (rb2d_en.velocity.x > -maxVelocity)
                rb2d_en.AddForce(new Vector2(-velocityDelta, zeroVelocity));

        }
        else if (rb2d_en.position.x < 10)
        {
            Debug.Log(rb2d_en.position.x);
            if (rb2d_en.velocity.x < maxVelocity)
                rb2d_en.AddForce(new Vector2(velocityDelta, zeroVelocity));
        }
    }

    void Attack()
    {
        // Jump as placeholder
        if (isGrounded)
        {
            rb2d_en.velocity += Vector2.up * 5.0f;
        }
    }
}

