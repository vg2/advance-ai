using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Assets.Scripts.Evolution.StringMatching;

namespace Assets.Scripts.Evolution.ClonalSelection
{
    public static class ClonalSelectionAlgorithms
    {
        public static IClonalSelection DefaultClonalSelection(ClonalSelectionConfiguration configuration)
        {
            return new DefaultClonalSelection(configuration);
        }

        public static IClonalSelection StringMatchingClonalSelection(ClonalSelectionConfiguration configuration, IStringMatchingRule stringMatchingRule)
        {
            return new StringMatchingClonalSelection(configuration, stringMatchingRule, new BinaryStringPresenter());
        }
    }
}
