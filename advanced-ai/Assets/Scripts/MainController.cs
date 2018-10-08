using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MainController : MonoBehaviour
    {
        private readonly Movement _movement;
        private readonly global::Evolution _evolution;
        private GameSetup _gameSetup;
        private List<OrigamiRobot> _robots;

        public MainController()
        {
            _movement = new Movement();
            _evolution = new global::Evolution();
            
        }

        public void StartGame(int robotsPerTeam)
        {
            _gameSetup = new GameSetup(robotsPerTeam, new DefaultWinCondition());
            _robots = new List<OrigamiRobot>(); // todo: replace with call to Robot Origin to generate robots

            throw new NotImplementedException();
        }


    }
}
