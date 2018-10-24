using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Main : MonoBehaviour {

    private MainController main; 
    void Start()
    {

        main = new MainController();
        main.Start();
        Debug.Log("Main Started");
    }

    
	
	// Update is called once per frame
	void Update () {
        main.Update();
        Debug.Log("Main Updated");
    }
}
