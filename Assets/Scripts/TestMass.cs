﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMass : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == false)
        {
            Test();
        }
    }

    void Test()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 225;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
    }
}
