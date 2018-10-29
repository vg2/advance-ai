using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationStats : MonoBehaviour {

    public Text n_antigen;
    public int counter = 0;
    
	
	// Update is called once per frame
	void Update () {

        n_antigen.text =  (counter + 1).ToString();

    }
}
