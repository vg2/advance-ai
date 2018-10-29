using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Evolution;

namespace Assets.Scripts
{
    public class GameState
    {
        public object GameBoard { get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public WinningTeam WinningTeam { get; set; }
        public LosingTeam LosingTeam { get; set; }
        public int MoveCount { get; set; }

        public GameState() {
            TeamA = new Team("Autobots");
            TeamB = new Team("Decepticon");
            WinningTeam = new WinningTeam();
            LosingTeam = new LosingTeam();
            MoveCount = 0;
        }

        public bool GameOver()
        {
            // Check if TeamA has active robots
            int teamA = TeamA.ActiveRobots().Count;
            // Check if TeamB has active robots
            int teamB = TeamA.ActiveRobots().Count;

            if (teamA > 0)
            {
                WinningTeam.setTeam(TeamA);
                LosingTeam.setTeam(TeamB);
                return true;
            }

            if (teamB > 0)
            {
                WinningTeam.setTeam(TeamB);
                LosingTeam.setTeam(TeamA);
                return true;
            }

            if (MoveCount > 1000)
            {
                teamA = TeamA.GetTeamFitness();
                teamB = TeamB.GetTeamFitness();

                if (teamA > teamB)
                {
                    WinningTeam.setTeam(TeamA);
                    LosingTeam.setTeam(TeamB);
                    return true;
                }

                if (teamB > teamA)
                {
                    WinningTeam.setTeam(TeamB);
                    LosingTeam.setTeam(TeamA);
                    return true;
                }
            }

            return false;
        }
    }
}
