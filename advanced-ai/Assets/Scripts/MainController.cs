using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MainController : MonoBehaviour
    {
        private readonly Movement _movement;
        private readonly global::Evolution _evolution;
        private List<OrigamiRobot> _robots;

        public MainController()
        {
            _movement = new Movement();
            _evolution = new global::Evolution();
        }

        public void StartGame()
        {
            _robots = new List<OrigamiRobot>(); // todo: replace with call to Robot Origin to generate robots

            throw new NotImplementedException();
        }


    }
}
