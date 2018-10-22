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

            for(int i = 0; i < SettingsContainer.numberOfBots; i++)
            {
                // Better init robots to match tiles
                GameObject tmp = GameObject.FindGameObjectsWithTag("UpTag")[0];
                // OrigamiRobot robot = new OrigamiRobot(this, 3, tmp);

                // _robots.Add(robot);
            }
        }

        public List<OrigamiRobot> GetRobots()
        {
            return _robots;
        }
    }
}
