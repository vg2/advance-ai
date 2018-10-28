using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Main : MonoBehaviour {

    private MainController main; 

    public void Start()
    {
        main = new MainController();
        main.Start();
        Debug.Log("Main Started");
    }

    
	
	// Update is called once per frame
	public void Update () {
        main.Update();
        Debug.Log("Main Updated");
    }
}
