using System;
using UnityEngine;

/*
 * Author: Siphesihle Sithungu
 * Descritption: Decision tree that represents the algorithm that the robots will follow.
 */
public class DecisionTree 
{
    //Used by terminal nodes to determine in which direction the robot should move.
    public enum Decision { None, N, S, NW, NE, SW, SE };

    //Used by function nodes to determine in which "state" the robot is currently in.
    public enum State { None, InOwnColony, InForeignColony, InCollision };

    private DTNode root;
    private int depth;

    public DecisionTree(int depth)
    {
        root = new DTNode(RandFunction(), Decision.None);
        this.depth = depth;
        RandomInit(); //Randomly initialise the tree for first use.
    }

    //-- Initializes the tree with random values. --//
    public void RandomInit()
    {
        int currentDepth = 0;
        Grow(root, currentDepth + 1);
    }

    //-- This function grows the tree recursively until the desired depth is met. --//
    private void Grow(DTNode parent, int currentDepth)
    {
        //Base case. Time to generate decision nodes.
        if(currentDepth == depth)
        {
            DTNode ld = new DTNode(State.None, RandDecision());
            DTNode rd = new DTNode(State.None, RandDecision());
            AddLeftChild(ld, parent);
            AddRightChild(rd, parent);
            return;
        }

        //Continue generating function nodes.
        DTNode lf = new DTNode(RandFunction(), Decision.None);
        DTNode rf = new DTNode(RandFunction(), Decision.None);
        AddLeftChild(lf, parent);
        AddRightChild(rf, parent);
        //Keep growing the tree.
        Grow(lf, currentDepth + 1);
        Grow(rf, currentDepth + 1);
    }

    private void AddRightChild(DTNode rd, DTNode parent)
    {
        parent.SetRightChild(rd);
        rd.SetParent(parent);
    }

    private void AddLeftChild(DTNode ld, DTNode parent)
    {
        parent.SetLeftChild(ld);
        ld.SetParent(parent);
    }

    //-- Generates and returns a random Decision --//
    private Decision RandDecision()
    {
        int r = UnityEngine.Random.Range(1, 7);
        switch (r)
        {
            case 1:
                return Decision.N;
            case 2:
                return Decision.NE;
            case 3:
                return Decision.NW;
            case 4:
                return Decision.S;
            case 5:
                return Decision.SE;
            case 6:
                return Decision.SW;
            default:
                throw new Exception("Invalid choice for a State.");
        }
    }

    //-- Generates and returns a random State. --//
    private State RandFunction()
    {
        int r = UnityEngine.Random.Range(1, 4);
        switch (r)
        {
            case 1:
                return State.InCollision;
            case 2:
                return State.InForeignColony;
            case 3:
                return State.InOwnColony;
            default:
                throw new Exception("Invalid choice for a State.");
        }
    }

    public DTNode GetRoot()
    {
        return root;
    }

    public int GetDepth()
    {
        return depth;
    }

    override
    public string ToString()
    {
        string output = "------------ROOT-----------\n\n";
        output += WalkTree(root);
        return output;
    }

    private string WalkTree(DTNode node)
    {
        string temp = "";
        //Base case.
        if (node.IsLeaf())
        {
            return node.GetDecision() + "\n";
        }

        temp += node.GetState() + "\n";
        temp += "-----Left Child-----\n";
        temp += WalkTree(node.GetLeftChild());
        temp += "-----Right Child-----\n";
        temp += WalkTree(node.GetRightChild());

        return temp;
    }

    public class DTNode
    {
        private DTNode leftChild;
        private DTNode rightChild;
        private DTNode parent;

        private State state;
        private Decision decision;

        public DTNode(State state, Decision decision)
        {
            this.state = state;
            this.decision = decision;
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

        public State GetState()
        {
            return state;
        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public Decision GetDecision()
        {
            return decision;
        }

        public void SetDecision(Decision decision)
        {
            this.decision = decision;
        }

        public void SetParent(DTNode parent)
        {
            this.parent = parent;
        }

        public DTNode GetParent()
        {
            return parent;
        }

        public Boolean IsLeaf()
        {
            return state == State.None;
        }
    }
}