using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Evolution.ClonalSelection
{
    public class ClonalSelectionConfiguration
    {
        public ClonalSelectionConfiguration(int affinityThreshold,
            int selectionLimit,
            int defaultCloneSize,
            int mutationProbabilityFactor)
        {
            AffinityThreshold = affinityThreshold;
            SelectionLimit = selectionLimit;
            DefaultCloneSize = defaultCloneSize;
            MutationProbabilityFactor = mutationProbabilityFactor;
        }

        public int AffinityThreshold { get; private set; }
        public int SelectionLimit { get; private set; }
        public int DefaultCloneSize { get; private set; }
        public int MutationProbabilityFactor { get; private set; }
    }
}
