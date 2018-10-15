using System;
namespace AssemblyCSharp.Assets.Scripts.Collision
{
    /*
     * Given two robots that collide, It will determine if the robots are on the same team or not
     * And if in different teams, it will either attack or defend
     * */
    public class RobotCollision
    {
		public RobotCollision()
        {
        }

        //Determines if the robot "other" is in same team as "self"
		public static Boolean IsSelf(OrigamiRobot self, OrigamiRobot other){
			return NSA.NonSelfDetection(self, other);
		}

        //Determines if the robot will attack or defend
        public void Analyse(OrigamiRobot self, OrigamiRobot other)
        {
            //TODO : Determine atc or def
            if(true)
            {
                Attack(self, other);
            }else
            {
                Defend(self, other);
            }
        }


        public void Defend(OrigamiRobot self, OrigamiRobot other)
        {
            //TODO : Move robot within cell


        }


		public static void Attack(OrigamiRobot self, OrigamiRobot other){

            //TODO : Decrease other robot health
			
		}

    }
}
