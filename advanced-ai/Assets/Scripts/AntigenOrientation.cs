using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Rendani Martin Mese
public class AntigenOrientation : MonoBehaviour {

	 public GameObject target; //the enemy's target
     public float moveSpeed = 5; //move speed
     public float rotationSpeed = 5; //speed of turning
     private Rigidbody rb;
    private Vector3 mytransform;
 
     void Start()
     {
        mytransform = target.transform.position;
         rb = GetComponent<Rigidbody>();
     }
 
 
    void Update()
     {
        if (transform != null)
        {
            //rotate to look at the player
            try
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);


                //move towards the player
                transform.position += transform.forward * Time.deltaTime * moveSpeed;

            }
            catch(MissingReferenceException e)
            {

            }
           
        }
         
 
     }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Untagged")
        {
            Destroy(collision.gameObject);
        }
    }
}
