using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Evolution
{
    class Mutation
    {
        internal static List<OrigamiRobot> mutate(List<OrigamiRobot> newPopulation)
        {
            return newPopulation.Select(mutate).ToList();
        }

        private static OrigamiRobot mutate(OrigamiRobot robot)
        {
            var currentBody = robot.getBody();

            var randomGenerator = new Random();

            //todo: replace with probability inversely proportionate to fitness of robot
            const double MutationProbability = 0.6;

            for (int i = 0; i < currentBody.Length; i++)
            {
                if (randomGenerator.NextDouble() > MutationProbability)
                {
                    currentBody[i] = Triangle.GenerateRandomTriangle(robot.GetRobotTransformProperties(), robot.GetPosition());
                }
            }

            return robot;
        }
    }
}
