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
            _movement = new Movement(1);
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
            // For TeamA move
            // For TeamB move

            // Check health of all robots, if 0 "deactivate"
            _gameState.TeamA.DeactivateDeadRobots();
            _gameState.TeamB.DeactivateDeadRobots();

            // Check winning condition
            if(_gameState.GameOver())
            {
                // If winning condition met
                Team copyOverTeam = _gameState.WinningTeam.getTeam();
                Team evolveTeam = _gameState.LosingTeam.getTeam();

                // Evolve robots
                Team evolvedTeam = _evolution.Evolve(evolveTeam, copyOverTeam);

                // Reset Simulation
                ResetSimulation(copyOverTeam, evolvedTeam);
            }
        }

        public void ResetSimulation(Team won, Team lost)
        {
            _gameState.MoveCount = 0;
            _gameState.TeamA = won;
            _gameState.TeamB = lost;
        }
    }
}
