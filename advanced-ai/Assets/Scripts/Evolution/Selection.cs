using System;
using System.Linq;
using System.Collections.Generic;

namespace Assets.Scripts.Evolution
{
    class Selection
    {
        /**
         * Have a tournament with a certain size of the population.
         * The individual with the best fitness is chosen.
         */
        public static OrigamiRobot tournament(List<OrigamiRobot> pop)
        {
            Random rnd = new Random();
            OrigamiRobot candidate = pop[rnd.Next(0, pop.Count - 1)];

            int tournamentSize = pop.Count / 5;
            int fights = 0;
            while(fights < tournamentSize)
            {
                OrigamiRobot opponent = pop[rnd.Next(0, pop.Count - 1)];
                if (candidate == opponent) break;

                if (opponent.fitness > candidate.fitness) {
                    candidate = opponent;
                }

                fights++;
            }

            return candidate;
        }

        /**
         * Choose a random indivual from the population.
         * Requires Elitism selection to be run in parallel.
         */
        public static OrigamiRobot random(List<OrigamiRobot> pop)
        {
            Random rnd = new Random();
            return pop[rnd.Next(0, pop.Count - 1)];
        }

        /**
         * Chooses the best individuals from the population.
         * Usually the populationSize should be between 1%-5%
         */
        public static List<OrigamiRobot> elitism(List<OrigamiRobot> old_pop, int populationSize)
        {
            List<OrigamiRobot> new_pop = new List<OrigamiRobot>();

            old_pop.OrderBy(o => o.fitness).ToList();

            for (int i = 0; i < populationSize; i++)
            {
                new_pop.Add(old_pop[i]);
            }

            return new_pop;
        }
    }
}
