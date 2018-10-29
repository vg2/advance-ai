using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibodyCollision : MonoBehaviour {

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

        r = new Random();
        //Check to see if the Collider's name is "Chest"
        if (collision.collider.tag == "antigen")
        {
            //Output the message
            if (collision.gameObject != null)
            {
                if (Random.Range(0, 20) < 5)
                {
                    Destroy(collision.gameObject);
                }
                Debug.Log("Antibody Collided with Antigen");
            }
        }
        
    }
}
