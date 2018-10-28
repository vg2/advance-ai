
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


        // using real valued representation (Vector3) for the detector so matching rule is Eucleadian
        public static double EuclideanDistance(Vector3 a, Vector3 b)
        {
            return Vector3.Distance(a, b);
        }
    }
}