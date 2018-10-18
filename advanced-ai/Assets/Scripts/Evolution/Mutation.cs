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
        private const double MutationProbabilityFactor = 10000;
        
        internal static List<OrigamiRobot> mutate(List<OrigamiRobot> newPopulation)
        {
            return newPopulation.Select(mutate).ToList();
        }

        private static OrigamiRobot mutate(OrigamiRobot robot)
        {
            var currentBody = robot.getBody();

            var randomGenerator = new Random();

            var mutationProbability = robot.fitness / MutationProbabilityFactor;            

            for (int i = 0; i < currentBody.Length; i++)
            {
                if (randomGenerator.NextDouble() > mutationProbability)
                {
                    currentBody[i] = Triangle.GenerateRandomTriangle(robot.GetRobotTransformProperties(), robot.GetPosition());
                }
            }

            return robot;
        }
    }
}
