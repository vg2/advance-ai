using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Martin Mese

public class AntigenCollision : MonoBehaviour
{

    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
       
    }

    //If your GameObject keeps colliding with another GameObject with a Collider, do something
    void OnCollisionStay(Collision collision)
    {

        //Check to see if the Collider's name is "Chest"
        if (collision.collider.tag == "antigen")
        {
            //Output the message
            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }
            Debug.Log("Bots collided");
        }
    }
}
