using System;
using System.Collections.Generic;
using UnityEngine;

    /*
    * Author: Xander Ferreira, Fortune Chidzikwe
    * Discription: Will decide which action to do within cell. Attack or defend
    *
   */

namespace AssemblyCSharp.Assets.Scripts.Collision
{
    /*
     * Given two robots that collide, It will determine if the robots are on the same team or not
     * And if in different teams, it will either attack or defend
     * */
    public class RobotCollision
    {
        Tree actionStrat;
        public RobotCollision()
        {
            //Initalising the tree with 3 levels
            actionStrat = new Tree(3);
        }

        
        public void DetermineAction(OrigamiRobot r)
        {
            Tree.DTNode currentNode = actionStrat.GetRoot();
            while (currentNode.GetDecision() == Tree.Decision.None)
            {
                /*if (IsStateOfRobot(currentNode.GetState(), r))
                {
                    //The answer is yes, move to left child.
                    currentNode = currentNode.GetLeftChild();
                }
                else
                {
                    //The answer is no, move to right child.
                    currentNode = currentNode.GetRightChild();
                }*/
            }

            //We have finally reached a decision node.
           // ExecuteMove(r);
        }

        private bool IsStateOfRobot(Tree.State state, Tree r)
        {
            if (state == Tree.State.defend)
            {
                //TODO
            }

            if (state == Tree.State.attack)
            {
                //TODO
            }

           
            throw new Exception("Robot is in an invalid state");
        }


        public void Defend(OrigamiRobot self, OrigamiRobot other)
        {
            //TODO : Move robot within cell


        }


        public static void Attack(OrigamiRobot self, OrigamiRobot other)
        {

            //TODO : Decrease other robot health

        }


        /*//Determines if the robot "other" is in same team as "self"
        public static Boolean IsSelf(OrigamiRobot self, OrigamiRobot other)
        {
            return NSA.NonSelfDetection(self, other);
        }*/

        //Determines if the robot will attack or defend
    }
}