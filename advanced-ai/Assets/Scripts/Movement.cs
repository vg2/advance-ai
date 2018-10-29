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

        //-- TOD: Move robots using decision tree. --//


        // ------------------------------------------------------------------------------------------ // End

        // ---------------------------------------- FC ----------------------------------------------
        // update all postions
        if (AntigenStimmulation())
        {
            PerformCollison();
        }
        
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


    private bool AntigenStimmulation()
    {
        return true;
    }

    private void PerformCollison()
    {
        //----------------------------------------------------------------------------------------- (on hold for now)
        // create and initalise Collision Class
        //TBD

        //----------------------------------------------------------------------------------------- // End
    }

    // ---------------------------------------- LG ----------------------------------------------
    private struct Detector
    {
        Vector3[] detected;
        bool friend;
    }


    public Vector3[] MovementStratGeneration(OrigamiRobot[] AllRobots)
    {
        Vector3[] Postions = new Vector3[AllRobots.Length];
        //Perform look around for each Oragami robot and insert new postion into Postions
        // Performing a Team check

        // Performing and enemy check

        // Deciding on optimal move

        return Postions;
    }

    private int[] antibodyEncoding(OrigamiRobot[] origamiRobots)
    {
        int[] antibody;
        if (origamiRobots.Length < 1)
        {
            antibody = null;
        }
        else
        {
            antibody = new int[origamiRobots.Length];
            // populate it by iterating orgami robots
            for (int i = 0; i < origamiRobots.Length; i++)
            {
                if (origamiRobots[i].GetTeam() == 1 )
                {
                    antibody[i] = ;
                }
                else
                {

                }
               
            }
        }
        

        // iterate the whole string and find what is important for the 
        return antibody;
    }

    private OrigamiRobot EvaluateMove(int[] antibody)
    {
        OrigamiRobot newOR = null;
        // Perform rotation check

        NSA(antibody);

        // perform next movement
        return newOR;
        
    }

    private void NSA(int[] antibody)
    {
        // generate detections
        for (int i = 0; i < antibody.Length; i++)
        {
            if (antibody[i] == 1)
            {
                // generate detectors for team a
                CreateDetector(teamA);
            }
            else
            if (antibody[i] == 0)
            {
                // generate detectors for team b
                CreateDetector(teamB);

            }
        }
        
    }

    private Detector CreateDetector(List<OrigamiRobot> team)
    {
        Detector d = new Detector();

        return d;
    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
