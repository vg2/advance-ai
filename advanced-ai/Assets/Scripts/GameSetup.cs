using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{ 
    public class GameSetup
    {
        public GameSetup(int robotsPerTeam,
            IWinCondition winCondition)
        {
            _robotsPerTeam = robotsPerTeam;
            _winCondition = winCondition;
        }

        private readonly int _robotsPerTeam;
        private readonly IWinCondition _winCondition;

        public int RobotsPerTeam
        {
            get { return _robotsPerTeam; }
        }

    }

    public class GameRules
    {
        public GameRules()
        {
        }
    }
}
