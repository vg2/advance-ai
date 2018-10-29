using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRenderer : MonoBehaviour
{
    //Author: Rendani Martin Mese
    //This code renders the origami on the map
    // Use this for initialization
    // The target marker.
    public Transform triangleA;
    public Transform triangleB;

    void Start()
    {

        for (int x = 0; x < 50; x++)
        {
            Instantiate(triangleB, new Vector3(-140, 12, 140), Quaternion.identity);
            Instantiate(triangleA, new Vector3(-140, 12, 140), Quaternion.identity);
        }

        
    }
    // Update is called once per frame
    void Update()
    {


    }
}
