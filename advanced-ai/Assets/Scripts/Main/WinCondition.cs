using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IWinCondition
    {
        WinningTeam DetermineWinningTeam(GameState gameState);
    }

    public class WinningTeam
    {
        private readonly string _teamName;

        public WinningTeam(string teamName)
        {
            _teamName = teamName;
        }

        public string TeamName
        {
            get { return _teamName; }
        }
    }

    public class DefaultWinCondition : IWinCondition
    {
        public WinningTeam DetermineWinningTeam(GameState gameState)
        {
            throw new NotImplementedException();
        }
    }

}
