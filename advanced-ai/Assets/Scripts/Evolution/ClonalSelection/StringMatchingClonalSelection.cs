using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Evolution.StringMatching;

namespace Assets.Scripts.Evolution.ClonalSelection
{
    public class StringMatchingClonalSelection : IClonalSelection
    {
        private readonly ClonalSelectionConfiguration _config;
        private readonly IStringMatchingRule _stringMatchingRule;
        private readonly IPresenter<OrigamiRobot, string> _robotStringPresenter;

        public StringMatchingClonalSelection(ClonalSelectionConfiguration config,
            IStringMatchingRule stringMatchingRule,
            IPresenter<OrigamiRobot, string> robotStringPresenter)
        {
            _config = config;
            _stringMatchingRule = stringMatchingRule;
            _robotStringPresenter = robotStringPresenter;
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
            var antibodyString = _robotStringPresenter.Present(antibody);
            var antigenString = _robotStringPresenter.Present(antigen);

            var affinity = _stringMatchingRule.MatchResult(antibodyString, antigenString);

            return affinity;
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
