using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Evolution.StringMatching
{
    public class BinaryStringPresenter : IPresenter<OrigamiRobot, string>
    {
        public string Present(OrigamiRobot presentableObject)
        {
            var result = new StringBuilder();

            var centreRepresentation = VectorToBinaryString(presentableObject.GetCentre());
            result.Append(centreRepresentation);

            var orientationRepresentation = VectorToBinaryString(presentableObject.GetRotation());
            result.Append(orientationRepresentation);

            foreach (var triangle in presentableObject.getBody())
            {
                result.Append(VectorToBinaryString(triangle.GetVertexA()));
                result.Append(VectorToBinaryString(triangle.GetVertexB()));
                result.Append(VectorToBinaryString(triangle.GetVertexC()));
            }

            return result.ToString();
        }

        private string VectorToBinaryString(Vector3 vector)
        {
            var xComponent = ((int) Math.Round(vector.x)) % 256;
            var xString = Convert.ToString(xComponent, 2)
                .PadLeft(8, '0');

            var yComponent = ((int) Math.Round(vector.y)) % 256;
            var yString = Convert.ToString(yComponent, 2)
                .PadLeft(8, '0');

            var zComponent = ((int) Math.Round(vector.z)) % 256;
            var zString = Convert.ToString(zComponent, 2)
                .PadLeft(8, '0');

            return string.Format("{0}{1}{2}", xString, yString, zString);
        }
    }
}
