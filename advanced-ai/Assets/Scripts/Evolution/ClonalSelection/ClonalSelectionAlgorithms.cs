using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Assets.Scripts.Evolution.ClonalSelection
{
    public static class ClonalSelectionAlgorithms
    {
        public static IClonalSelection DefaultClonalSelection(ClonalSelectionConfiguration configuration)
        {
            return new DefaultClonalSelection(configuration);
        }
    }
}
