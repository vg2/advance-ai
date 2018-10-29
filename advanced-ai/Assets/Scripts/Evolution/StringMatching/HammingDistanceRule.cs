using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Evolution.StringMatching
{
    public class HammingDistanceRule : IStringMatchingRule
    {
        public int MatchResult(string x, string y)
        {
            var comparisonLength = Math.Min(x.Length, y.Length);

            var differences = 0;

            for (var i = 0; i < comparisonLength; i++)
            {
                if (x[i] != y[i])
                {
                    differences++;
                }
            }

            return differences;
        }
    }
}
