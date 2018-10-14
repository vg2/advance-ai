using System;
namespace AssemblyCSharp.Assets.Scripts.Collision
{
    public class RobotCollision
    {
		public RobotCollision()
        {
        }

		public static Boolean IsSelf(OrigamiRobot self, OrigamiRobot other){
			return NSA.NonSelfDetection(self, other);
		}

		public static void Attack(OrigamiRobot self, OrigamiRobot other){

            //TODO
			
		}

    }
}
