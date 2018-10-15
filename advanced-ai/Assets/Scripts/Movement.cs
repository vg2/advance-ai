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
    private List<OrigamiRobot> teamA;
    private List<OrigamiRobot> teamB;

    private int RandomNumber(int Min, int Max)
    {
        System.Random r = new System.Random();
        int value = r.Next(Min, Max);
        return value;
    }

    // MoveRobots
    public void MoveRobots(OrigamiRobot[] or)
    {
        List<Vector3> TeamAPositions; // will be the next postion of every robot in team A
        List<Vector3> TeamBPositions; // will be the next postion of every robot in team B

        // ---------------------------------------- SS ----------------------------------------------
        /*
         *Description: Split into team A and team B
         * Collect postions of robots per team and perform movement (MovementStratGeneration)
         */

        //-- Split into Team A and Team B and collect positions of the robots. --//
        teamA = new List<OrigamiRobot>();
        teamB = new List<OrigamiRobot>();
        TeamAPositions = new List<Vector3>();
        TeamBPositions = new List<Vector3>();

        for (int i = 0; i < or.Length; i++)
        {
            if (or[i].GetTeam() == 0)
            {
                //Robot belongs to Team A.
                teamA.Add(or[i]);
                TeamAPositions.Add(or[i].GetPosition());
            }

            else
            {
                //Robot belongs to Team B.
                teamB.Add(or[i]);
                TeamBPositions.Add(or[i].GetPosition());
            }  
        }

        //-- Move robots. --//


        // ------------------------------------------------------------------------------------------ // End

        // ---------------------------------------- FC ----------------------------------------------
        // update all postions
        // Perform collision where robots are moving into the same postion
        // ------------------------------------------------------------------------------------------ // End

        //check collision distance between bots

        //for(Vector3 botAPosition : TeamAPostions)
        //{
        //    for(Vector3 botBPosition : TeamBPostions)
        //    {
        //        distance = Vector3.Distance(botAPosition, botBPosition);
        //        if(distance <= minCollisionDistance){
        //            Collision.Collide(botAPosition, botBPosition);
        //        }
        //    }
        //}

    }

    // ---------------------------------------- LG ----------------------------------------------
    private struct Detector
    {
        float detected;
        bool friend;
    }


    public Vector3[] MovementStratGeneration(OrigamiRobot[] AllRobots, OrigamiRobot[] OrTeam)
    {
        Vector3[] Postions = new Vector3[OrTeam.Length];
        //Perform look around for each Oragami robot and insert new postion into Postions
        // Performing a Team check

        // Performing and enemy check

        // Deciding on optimal move

        return Postions;
    }

    private OrigamiRobot EvaluateMove(char team)
    {
        OrigamiRobot newOR = null;
        // Perform rotation check

        NSA(team);

        // perform next movement
        return newOR;
        
    }

    private void NSA(char team)
    {
        // generate detections
        if (team == 'a')
        {
            // generate detectors for team a
            CreateDetector(teamA);
        }
        else 
        if(team == 'b')
        {
            // generate detectors for team b
            CreateDetector(teamB);

        }
    }

    private Detector CreateDetector(List<OrigamiRobot> team)
    {
        Detector d = new Detector();

        return d;
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
