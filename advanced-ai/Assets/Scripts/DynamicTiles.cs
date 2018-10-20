using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTiles : MonoBehaviour {



   public GameObject[] hexagons;
    // Use this for initialization
    void Start () {
            hexagons = GameObject.FindGameObjectsWithTag("DownTag");

        if (hexagons != null)
        {
            foreach(GameObject hexagon in hexagons)
            {
                hexagon.SetActive(false);
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
