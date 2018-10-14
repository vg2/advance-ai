
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Collision
{
    public class MatchingRule
    {
        public MatchingRule()
        {
        }

        public static double EuclideanDistance(Vector3 a, Vector3 b){
            return Vector3.Distance(a,b);
        }
    }
}
