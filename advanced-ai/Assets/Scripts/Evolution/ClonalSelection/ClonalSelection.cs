using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;

namespace Assets.Scripts.Evolution.ClonalSelection
{
    public class ClonalSelection
    {
        private readonly ClonalSelectionConfiguration _config;

        public ClonalSelection(ClonalSelectionConfiguration config)
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

                if (affinity > _config.AffinityThreshold)
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
            /* Determine Affinty */
            return 10;
        }

        private List<OrigamiRobot> CloneAndMutate(OrigamiRobot antibody, OrigamiRobot currentAntigen)
        {
            var numberOfClones = _config.DefaultCloneSize * DetermineAffinity(antibody, currentAntigen);
            var clones = new List<OrigamiRobot>();

            for (var i = 0; i < numberOfClones; i++)
            {
                clones.Add(new OrigamiRobot(antibody.GetTeam(), antibody.GetNumParts(), antibody.GetRobotTransformProperties()));
            }

            return Mutation.Mutate(clones);
        }
    }
}
