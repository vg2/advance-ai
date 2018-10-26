using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Team
    {
        private List<OrigamiRobot> _robots;
        private int _teamFitness;
        private string _teamID;

        public Team(string teamID)
        {
            _teamID = teamID;
            _teamFitness = 0;
        }

        public void InitRobots()
        {
            _robots = new List<OrigamiRobot>();

            for(int i = 0; i < GameObject.FindGameObjectsWithTag("UpTag").Length; i++)
            {
                // Better init robots to match tiles

                GameObject tile = GameObject.FindGameObjectsWithTag("UpTag")[i];

                Debug.Log("Creating robot");
                OrigamiRobot robot = new OrigamiRobot(this, 3, tile);
                _robots.Add(robot);
                Debug.Log("Robot created");
            }
        }

        public List<OrigamiRobot> GetRobots()
        {
            return _robots;
        }
        
        public string GetID()
        {
            return _teamID;
        }
    }
}
