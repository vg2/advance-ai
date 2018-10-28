using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Evolution.StringMatching
{
    public class BinaryDistanceRule : IStringMatchingRule
    {
        public int MatchResult(string x, string y)
        {
            var a = BasicMeasureA(x, y);
            var b = BasicMeasureB(x, y);
            var c = BasicMeasureC(x, y);
            var d = BasicMeasureD(x, y);

            return RusselAndRaoSimilarity(a,b,c,d);
        }

        private int BasicMeasureA(string x, string y)
        {
            var comparisonLength = Math.Min(x.Length, y.Length);

            var distanceMeasure = 0;

            for (var i = 0; i < comparisonLength; i++)
            {
                if (x[i] == '1' && y[i] == '1')
                {
                    distanceMeasure++;
                }
            }

            return distanceMeasure;
        }

        private int BasicMeasureB(string x, string y)
        {
            var comparisonLength = Math.Min(x.Length, y.Length);

            var distanceMeasure = 0;

            for (var i = 0; i < comparisonLength; i++)
            {
                if (x[i] == '1' && y[i] == '0')
                {
                    distanceMeasure++;
                }
            }

            return distanceMeasure;
        }

        private int BasicMeasureC(string x, string y)
        {
            var comparisonLength = Math.Min(x.Length, y.Length);

            var distanceMeasure = 0;

            for (var i = 0; i < comparisonLength; i++)
            {
                if (x[i] == '0' && y[i] == '1')
                {
                    distanceMeasure++;
                }
            }

            return distanceMeasure;
        }

        private int BasicMeasureD(string x, string y)
        {
            var comparisonLength = Math.Min(x.Length, y.Length);

            var distanceMeasure = 0;

            for (var i = 0; i < comparisonLength; i++)
            {
                if (x[i] == '0' && y[i] == '0')
                {
                    distanceMeasure++;
                }
            }

            return distanceMeasure;
        }


        private int RusselAndRaoSimilarity(int a, int b, int c, int d)
        {
            var result = a / (a + b + c + d);

            return result;
        }

        private int JacardAndNeedhamSimilarity(int a, int b, int c, int d)
        {
            return a / (a + b + c);
        }

        private int KulzinskiSimilarity(int a, int b, int c, int d)
        {
            return a / (b + c + 1);
        }

        private int SokalAndMichener(int a, int b, int c, int d)
        {
            return (a + d) / (a + b + c + d);
        }

        private int RogersAndTanimoto(int a, int b, int c, int d)
        {
            return (a + d) / (a + d + (2 * (b + c)));
        }

        private int YuleSimilarity(int a, int b, int c, int d)
        {
            return (a * d - b * c) / (a * d + b * c);
        }
    }
}
