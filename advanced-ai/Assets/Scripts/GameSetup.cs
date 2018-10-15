using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{ 
    public class GameSetup
    {
        public GameSetup(IWinCondition winCondition)
        {
            _winCondition = winCondition;
        }

        private readonly IWinCondition _winCondition;
    }

    public class GameRules
    {
        public GameRules()
        {
        }
    }
}
