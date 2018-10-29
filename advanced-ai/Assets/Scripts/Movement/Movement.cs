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
    private List<OrigamiRobot> teamA;
    private List<OrigamiRobot> teamB;
    private static int stimmilation = 2;
    private System.Random rnd;
    private List<Detector> detectorList;

    private int RandmNumber(int value)
    {
        return rnd.Next(value);
    }

    private int RandomNumber(int Min, int Max)
    {
        System.Random r = new System.Random();
        int value = r.Next(Min, Max);
        return value;
    }
    DecisionTree movementStrategy; //Sequence of steps that the robot follows to make a movement decision.
    List<OrigamiRobot> robots;

    public Movement(int treeDepth)
    {
        //Instantiate the three with the desired depth.
        movementStrategy = new DecisionTree(treeDepth);
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
        ExecuteMoveExecuteMove(r);
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

    private int[] antibodyEncoding(OrigamiRobot[] origamiRobots, OrigamiRobot currentRobot)
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
                if (origamiRobots[i].GetTeam() != currentRobot.GetTeam())
                {

                    if (!(checkDistance(origamiRobots, currentRobot) > stimmilation))
                    {
                        antibody[i] = 1;
                        teamA.Add(origamiRobots[i]);
                    }
                    else
                    {
                        antibody[i] = 0;
                    }
                }
                else
                {
                    antibody[i] = 0;
                    teamB.Add(origamiRobots[i]);
                }

            }
        }

        // iterate the whole string and find what is important for the 
        return antibody;
    }

    private int checkDistance(OrigamiRobot[] origamiRobots, OrigamiRobot currentRobot)
    {
        // sends an ine for the number of searched values
        int decsion = 0;
        int currentTeam = ;
        for (int i = 0; i < origamiRobots.Length; i++)
        {
            if ((Math.Abs(origamiRobots[i].GetPosition().x - currentRobot.GetPosition().x) <= 5) &&
                 (Math.Abs(origamiRobots[i].GetPosition().z - currentRobot.GetPosition().z) <= 5) &&
                 (Math.Abs(origamiRobots[i].GetPosition().y - currentRobot.GetPosition().y) <= 5) &&
                 (origamiRobots[i].GetTeam() != currentRobot.GetTeam()))
            {
                decsion++;
            }

        }
        return decsion;
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
                detectorList.Add(CreateDetector(teamA));

            }
            else
            if (antibody[i] == 0)
            {
                // generate detectors for team b
                detectorList.Add(CreateDetector(teamB));

            }
        }

    }
    

    private Detector CreateDetector(OrigamiRobot robotDetected)
    {
        Detector d = new Detector();
        return d;
    }


    // Use this for initialization
    void Start()
    {
        rnd = new System.Random();
        teamA = new List<OrigamiRobot>();
        teamB = new List<OrigamiRobot>();
        detectorList = new List<Detector>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
