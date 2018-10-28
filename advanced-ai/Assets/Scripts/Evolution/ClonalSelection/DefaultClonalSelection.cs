using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;

namespace Assets.Scripts.Evolution.ClonalSelection
{
    public class DefaultClonalSelection : IClonalSelection
    {
        private readonly ClonalSelectionConfiguration _config;

        public DefaultClonalSelection(ClonalSelectionConfiguration config)
        {
            _config = config;
        }

        public Team Execute(Team antibodyTeam, Team antigenTeam)
        {
            foreach (var antigen in antigenTeam.GetRobots())
            {
                var eligibleAntibodies = GetRobotsEligibleForCloning(antibodyTeam, antigen);

                foreach (var eligibleAntibody in eligibleAntibodies)
                {
                    var mutatedClones = CloneAndMutate(eligibleAntibody, antigen);

                    /* what updates fitness? */
                    var bestClone = mutatedClones.OrderByDescending(c => c.fitness).First();

                    /* this might break loop */
                    var indexToReplace = antibodyTeam.GetRobots().IndexOf(eligibleAntibody);
                    antibodyTeam.GetRobots()[indexToReplace] = bestClone;
                }
            }

            return antibodyTeam;
        }

        private List<OrigamiRobot> GetRobotsEligibleForCloning(Team antibodyTeam, OrigamiRobot currentAntigen)
        {
            var eligibleRobots = new List<OrigamiRobot>();

            foreach (var antibody in antibodyTeam.GetRobots())
            {
                var affinity = DetermineAffinity(antibody, currentAntigen);

                if (affinity <= _config.AffinityThreshold)
                {
                    eligibleRobots.Add(antibody);
                }

                if (eligibleRobots.Count >= _config.SelectionLimit)
                {
                    break;
                }
            }

            return eligibleRobots;
        }

        private int DetermineAffinity(OrigamiRobot antibody, OrigamiRobot antigen)
        {
            var min = int.MaxValue;

            foreach (var triangle in antibody.getBody())
            {
                foreach (var antigenTriangle in antigen.getBody())
                {
                    var vertexADiff = Math.Abs(
                                        (triangle.GetVertexA().x - antigenTriangle.GetVertexA().x) 
                                        + (triangle.GetVertexA().y - antigenTriangle.GetVertexA().y) 
                                        + (triangle.GetVertexA().z - antigenTriangle.GetVertexA().z)
                                    );

                    var vertexBDiff = Math.Abs(
                        (triangle.GetVertexB().x - antigenTriangle.GetVertexB().x)
                        + (triangle.GetVertexB().y - antigenTriangle.GetVertexB().y)
                        + (triangle.GetVertexB().z - antigenTriangle.GetVertexB().z)
                    );

                    var vertexCDiff = Math.Abs(
                        (triangle.GetVertexC().x - antigenTriangle.GetVertexC().x)
                        + (triangle.GetVertexC().y - antigenTriangle.GetVertexC().y)
                        + (triangle.GetVertexC().z - antigenTriangle.GetVertexC().z)
                    );

                    var diffs = new [] {vertexADiff, vertexBDiff, vertexCDiff};

                    var minDiff = diffs.Min();

                    if (minDiff < min)
                    {
                        min = (int)Math.Floor(minDiff);
                    }
                }
            }

            return min;
        }

        private List<OrigamiRobot> CloneAndMutate(OrigamiRobot antibody, OrigamiRobot currentAntigen)
        {
            var numberOfClones = _config.DefaultCloneSize * DetermineAffinity(antibody, currentAntigen);
            var clones = new List<OrigamiRobot>();

            for (var i = 0; i < numberOfClones; i++)
            {
                clones.Add(new OrigamiRobot(antibody.GetTeam(), antibody.GetNumParts(), antibody.GetRobotTile()));
            }

            return Mutation.Mutate(clones);
        }
    }
}
