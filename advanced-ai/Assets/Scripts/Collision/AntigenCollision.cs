﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Martin Mese

public class AntigenCollision : MonoBehaviour
{

    private Random r;

    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
       
    }

    //If your GameObject keeps colliding with another GameObject with a Collider, do something
    void OnCollisionStay(Collision collision)
    {

        if (collision.collider.tag == "antibody")
        {
            //Output the message
            if (collision.gameObject != null)
            {
                if (Random.Range(0, 20) < 5)
                {
                    Destroy(collision.gameObject);
                }
                Debug.Log("Antigen Collided with Antibody");
            }
        }
    }
}
