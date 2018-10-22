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

        public GameState() {
            TeamA = new Team("Autobots");
            TeamB = new Team("Decepticon");
        }
    }
}
