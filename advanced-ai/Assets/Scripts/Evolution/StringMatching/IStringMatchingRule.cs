using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Evolution.StringMatching
{
    public interface IStringMatchingRule
    {
        int MatchResult(string x, string y);
    }
}
