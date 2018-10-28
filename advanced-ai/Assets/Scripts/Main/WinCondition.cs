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
        private Team _team = null;

        public Team getTeam()
        {
            return _team;
        }

        public void setTeam(Team team)
        {
            _team = team;
        }
    }

    public class LosingTeam
    {
        private Team _team = null;

        public Team getTeam()
        {
            return _team;
        }

        public void setTeam(Team team)
        {
            _team = team;
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
