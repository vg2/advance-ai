using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    /*
     *Author: Lance Govender (LG), Sihle Sithungu (SS), Fortune Chidzikwe (FC)
     *Discription: Performs movement stats for each robots using team wide immunological computation elements
    */


    // MoveRobots
    public void MoveRobots(OrigamiRobot[] or)
    {
        Vector3[] TeamAPostions; // will be the next postion of every robot in team A
        Vector3[] TeamBPostions; // will be the next postion of every robot in team B



        // ---------------------------------------- SS ----------------------------------------------
        // Split into team A and team B
        // Collect postions of robots per team and perform movement (MovementStratGeneration)
        // ------------------------------------------------------------------------------------------


        // ---------------------------------------- FC ----------------------------------------------
        // update all postions
        // Perform collision where robots are moving into the same postion
        // ------------------------------------------------------------------------------------------
    }

    // ---------------------------------------- LG ----------------------------------------------
    public Vector3[] MovementStratGeneration(OrigamiRobot[] OrTeam)
    {
        Vector3[] Postions = new Vector3[OrTeam.Length];
        //Perform look around for each Oragami robot and insert new postion into Postions

        return Postions;
    }


    //----------------------------------------------------------------------------------------- (on hold for now)
    // create and initalise Collision Class
    //TBD

    //-----------------------------------------------------------------------------------------


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
