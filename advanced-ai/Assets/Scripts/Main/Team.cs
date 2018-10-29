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

            for (int i = 0; i < GameObject.FindGameObjectsWithTag("UpTag").Length; i++)
            {
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

        public List<OrigamiRobot> ActiveRobots()
        {
            List<OrigamiRobot> robots = new List<OrigamiRobot>();

            // Add if has health

            return robots;
        }

        public List<OrigamiRobot> DeactiveRobots()
        {
            List<OrigamiRobot> robots = new List<OrigamiRobot>();

            // Add if has no health

            return robots;
        }

        public void DeactivateDeadRobots()
        {
            for (int i = 0; i < _robots.Count; i++)
            {
                // Check robot health
                // If 0 deactivate
            }
        }

        public string GetID()
        {
            return _teamID;
        }

        public int GetTeamFitness()
        {
            return _teamFitness;
        }
    }
}
