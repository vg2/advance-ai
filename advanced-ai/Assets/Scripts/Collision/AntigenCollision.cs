using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Author: Martin Mese

public class AntigenCollision : MonoBehaviour
{

    private Random r;
    public Text n_antibodies;
    public Text n_antigens;
    public Text n_collisions;
    private int counter;
    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
       
    }
    private void Start()
    {
        n_antigens.text = "Antigens: " + 0;
        n_antibodies.text = "Antibodies: " + 0;
        n_collisions.text = "Collisions: " + 0;
    }
    private void Update()
    {
        
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
                n_collisions.text = "Collisions: " + counter++;
                Debug.Log("Antigen Collided with Antibody");
            }
        }
    }
}
