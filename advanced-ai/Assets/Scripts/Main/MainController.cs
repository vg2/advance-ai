using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MainController
    {
        private readonly Movement _movement;
        private readonly global::Evolution _evolution;
        private GameSetup _gameSetup;
        private GameState _gameState;

        public MainController()
        {
            _movement = new Movement();
            _evolution = new global::Evolution();
            _gameState = new GameState();
        }

        public void Start()
        {
            _gameSetup = new GameSetup(new DefaultWinCondition());

            _gameState.TeamA.InitRobots();
            _gameState.TeamB.InitRobots();
        }

        public void Update()
        {

        }
    }
}
