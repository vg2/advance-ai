using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    /*
     * Author: Lance Govender (LG), Sihle Sithungu (SS), Fortune Chidzikwe (FC)
     * Discription: Performs movement stats for each robots using team wide immunological computation elements
     * Behavour Parameters : Aggression - biases the bots to attack over run
    */
    private int Aggression;

    private int RandomNumber(int Min, int Max)
    {
        System.Random r = new System.Random();
        int value = r.Next(Min, Max);
        return value;
    }

    // MoveRobots
    public void MoveRobots(OrigamiRobot[] or)
    {
        Vector3[] TeamAPostions; // will be the next postion of every robot in team A
        Vector3[] TeamBPostions; // will be the next postion of every robot in team B



        // ---------------------------------------- SS ----------------------------------------------
        // Split into team A and team B
        // Collect postions of robots per team and perform movement (MovementStratGeneration)
        // ------------------------------------------------------------------------------------------ // End


        // ---------------------------------------- FC ----------------------------------------------
        // update all postions
        // Perform collision where robots are moving into the same postion
        // ------------------------------------------------------------------------------------------ // End
    }

    // ---------------------------------------- LG ----------------------------------------------
    public Vector3[] MovementStratGeneration(OrigamiRobot[] AllRobots, OrigamiRobot[] OrTeam)
    {
        Vector3[] Postions = new Vector3[OrTeam.Length];
        //Perform look around for each Oragami robot and insert new postion into Postions
        // Performing a Team check

        // Performing and enemy check

        // Deciding on optimal move

        return Postions;
    }

    private OrigamiRobot EvaluateMove()
    {
        OrigamiRobot newOR = null;
        // Perform rotation check

        // perform next movement
        return newOR;
        
    }

    //----------------------------------------------------------------------------------------- (on hold for now)
    // create and initalise Collision Class
    //TBD

    //----------------------------------------------------------------------------------------- // End


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
