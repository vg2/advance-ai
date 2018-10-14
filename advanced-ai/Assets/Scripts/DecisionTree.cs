using System;

/*
 * Author: Siphesihle Sithungu
 * Descritption: Decision that represents an algorithm that the robots will follow.
 */
public class DecisionTree 
{
    //Used by terminal nodes to determine in which direction the robot should move.
    private enum Decision { N, S, NW, NE, SW, SE };

    //Used by function nodes to determine in which "state" the robot is currently in.
    private enum State { InOwnColony, InForeignColony, InCollision };

    public DecisionTree(int depth)
    {
        RandomInit(depth); //Randomly initialise the tree for first use.
    }

    //-- Initializes the tree with random values. --//
    private void RandomInit(int depth)
    {
        //TODO: build a n-deep tree with random functions and decisions.
        throw new NotImplementedException();
    }

    private State RandomFunction()
    {
        int r = UnityEngine.Random.Range(1, 3);
        switch (r)
        {
            case 1:
                return State.InCollision;
            case 2:
                return State.InForeignColony;
            case 3:
                return State.InOwnColony;
            default:
                throw new Exception("Invalid choice for State.");
        }
    }

    private class DTNode
    {
        private DTNode leftChild;
        private DTNode rightChild;
        private State function;
        private Decision decision;

        public DTNode(State function, Decision decision, DTNode leftChild, DTNode rightChild)
        {
            this.function = function;
            this.decision = decision;
            this.leftChild = leftChild;
        }

        public DTNode GetLeftChild()
        {
            return leftChild;
        }

        public void SetLeftChild(DTNode leftChild)
        {
            this.leftChild = leftChild;
        }

        public DTNode GetRightChild()
        {
            return rightChild;
        }

        public void SetRightChild(DTNode rightChild)
        {
            this.rightChild = rightChild;
        }

        public State GetFunction()
        {
            return function;
        }

        public void SetFunction(State function)
        {
            this.function = function;
        }

        public Decision GetDecision()
        {
            return decision;
        }

        public void SetDecision(Decision decision)
        {
            this.decision = decision;
        }
    }
}