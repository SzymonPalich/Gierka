﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCenterOfMass : MonoBehaviour
{
    public float currForce;
    public float Force;
    public GameObject DzidaObject;
    public GameObject Player;

    void Start()
    {

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            //Vector3 mousePlacement = Input.mousePosition;
            //Debug.Log(Player.transform.position.x + " : " + (mousePlacement.x - Screen.width / 2));
            //Debug.Log(Player.transform.position.y + " : " + (mousePlacement.y - Screen.height / 2));
            Shoot();
        }
    }

    void Shoot()
    {
        
        float ScreenWidthCenter = Screen.width / 2;
        float ScreenHeigthCenter = Screen.height / 2;
        Vector3 mousePlacement = Input.mousePosition;

        if (mousePlacement.x < ScreenWidthCenter) currForce = Force;
        else currForce = -Force;
        Debug.Log((mousePlacement.x + ":" + ScreenWidthCenter + ":" + currForce));
        GameObject Dzida = Instantiate(DzidaObject, transform.position, transform.rotation);
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                        mousePlacement.x - Screen.width,
                                                        mousePlacement.y,
                                                        1));
        Dzida.GetComponent<Rigidbody2D>().AddForce(mouseWorld * currForce);
    }
}
