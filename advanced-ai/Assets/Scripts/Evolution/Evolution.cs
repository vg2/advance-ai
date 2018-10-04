using Assets.Scripts.Evolution;
using System.Collections.Generic;

public class Evolution {

    public List<OrigamiRobot> evolve(List<OrigamiRobot> old_pop)
    {
        List<OrigamiRobot> new_pop = new List<OrigamiRobot>();

        // Selection
        while (new_pop.Count != old_pop.Count)
        {
            OrigamiRobot parent1 = Selection.tournament(old_pop);
            OrigamiRobot parent2 = Selection.tournament(old_pop);
            while (parent1 == parent2)
            {
                 parent2 = Selection.tournament(old_pop);
            }

            // Breeding / Cloning
            OrigamiRobot child = Breeding.crossover(parent1, parent2);

            new_pop.Add(child);
        }

        // Mutation
        new_pop = Mutation.mutate(new_pop);

        return new_pop;
    }
}
