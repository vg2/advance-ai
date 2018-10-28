using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Movement {

    /*
     * Author: Lance Govender (LG), Sihle Sithungu (SS), Fortune Chidzikwe (FC)
     * Discription: Performs movement stats for each robots using team wide immunological computation elements
     * Behavour Parameters : Aggression - biases the bots to attack over run
    */
    private int Aggression;
    DecisionTree movementStrategy; //Sequence of steps that the robot follows to make a movement decision.
    List<OrigamiRobot> robots;

    public Movement(int treeDepth)
    {
        //Instantiate the three with the desired depth.
        movementStrategy = new DecisionTree(treeDepth);
    }

    private int RandomNumber(int Min, int Max)
    {
        System.Random r = new System.Random();
        int value = r.Next(Min, Max);
        return value;
    }

    // MoveRobots
    public void MoveRobots(Team teamA, Team teamB)
    {
        List<Vector3> TeamAPositions; // will be the next postion of every robot in team A
        List<Vector3> TeamBPositions; // will be the next postion of every robot in team B

        // ---------------------------------------- SS ----------------------------------------------
        /*
         *Description: Split into team A and team B
         * Collect postions of robots per team and perform movement (MovementStratGeneration)
         */

        //-- Split into Team A and Team B and collect positions of the robots. --//
        TeamAPositions = new List<Vector3>();
        TeamBPositions = new List<Vector3>();

        foreach (OrigamiRobot r in teamA.GetRobots())
        {
                //Robot belongs to Team A.
                TeamAPositions.Add(r.GetPosition());
        }

        foreach (OrigamiRobot r in teamB.GetRobots())
        {
            //Robot belongs to Team B.
            TeamBPositions.Add(r.GetPosition());
        }

        //-- Use Decision Tree to move robots --//
        robots = new List<OrigamiRobot>();
        robots.AddRange(teamA.GetRobots());
        robots.AddRange(teamB.GetRobots());

        foreach(OrigamiRobot r in teamA.GetRobots())
        {
            DetermineMove(r);
        }

        foreach (OrigamiRobot r in teamB.GetRobots())
        {
            DetermineMove(r);
        }
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

    private void DetermineMove(OrigamiRobot r)
    {
        DecisionTree.DTNode currentNode = movementStrategy.GetRoot();
        while(currentNode.GetDecision() == DecisionTree.Decision.None)
        {
            if (IsStateOfRobot(currentNode.GetState(), r))
            {
                //The answer is yes, move to left child.
                currentNode = currentNode.GetLeftChild();
            }
            else
            {
                //The answer is no, move to right child.
                currentNode = currentNode.GetRightChild();
            }
        }

        //We have finally reached a decision node.
        ExecuteMove(r);
    }

    private bool IsStateOfRobot(DecisionTree.State state, OrigamiRobot r)
    {
        if(state == DecisionTree.State.InCollision)
        {
            foreach (OrigamiRobot rc in robots)
            {
                if(!rc.Equals(r) && rc.GetRobotTile().Equals(r.GetRobotTile()))
                {
                    //The two robots are in the same tile.
                    return true;
                }
            }
        }

        if (state == DecisionTree.State.InForeignColony)
        {
            if (r.GetTeam().GetID() == "1")
            {
                //Robot's colony is UpTag.
                return r.GetRobotTile().CompareTag("DownTag");
            }

            if (r.GetTeam().GetID() == "2")
            {
                //Robot's colony is DownTag.
                return r.GetRobotTile().CompareTag("UpTag");
            }
        }

        if (state == DecisionTree.State.InOwnColony)
        {
            if (r.GetTeam().GetID() == "1")
            {
                //Robot's colony is UpTag.
                return r.GetRobotTile().CompareTag("UpTag");
            }

            if (r.GetTeam().GetID() == "2")
            {
                //Robot's colony is DownTag.
                return r.GetRobotTile().CompareTag("DownTag");
            }
        }

        throw new Exception("Robot is in an invalid state");
    }

    /*
     * Part of the "update positions" sections for FC
     */
    private void ExecuteMove(OrigamiRobot r)
    {
        
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
           // CreateDetector(teamA);
        }
        else 
        if(team == 'b')
        {
            // generate detectors for team b
          //  CreateDetector(teamB);

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
