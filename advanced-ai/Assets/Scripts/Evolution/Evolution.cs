using Assets.Scripts.Evolution;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Evolution.ClonalSelection;

public class Evolution
{
    private IClonalSelection _clonalSelection;

    public Evolution()
    {
        _clonalSelection = ClonalSelectionAlgorithms.DefaultClonalSelection(new ClonalSelectionConfiguration(
            affinityThreshold:1,
            selectionLimit:10,
            defaultCloneSize:100,
            mutationProbabilityFactor:10
        ));
    }

    public Team Evolve(Team losingTeamToEvolve, Team otherTeam)
    {
        return _clonalSelection.Execute(losingTeamToEvolve, otherTeam);
    }
}
