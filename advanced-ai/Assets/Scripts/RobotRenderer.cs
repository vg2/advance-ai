using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRenderer : MonoBehaviour {
    //Author: Rendani Martin Mese
    //This code renders the origami on the map
    // Use this for initialization
    // The target marker.
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sideForce = 500f;

    void Start ()
    {
	
        
	}
	// Update is called once per frame
	void Update ()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("w"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
       
    }
}
