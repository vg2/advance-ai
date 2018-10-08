using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class GameState
    {
        public object GameBoard { get; set; }
        public List<OrigamiRobot> TeamA { get; set; }
        public List<OrigamiRobot> Teamb { get; set; }
    }
}
