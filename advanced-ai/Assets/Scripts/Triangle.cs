using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class Triangle
{
    /*
     * Author: Siphesihle Sithungu
     * Description: This class represents a triangle. Each vertex of a triangle is a Vector3.
     */
    private Vector3 vertexA;
    private Vector3 vertexB;
    private Vector3 vertexC;
    private List<Triangle> neighbours;
    private List<int> vacantSides;

    public Triangle(Vector3 vertexA, Vector3 vertexB, Vector3 vertexC)
    {
        this.vertexA = vertexA;
        this.vertexB = vertexB;
        this.vertexC = vertexC;

        neighbours = new List<Triangle>(3);
        vacantSides = new List<int>(3)
        {
            1,
            2,
            3
        };
    }

    public bool LinkNeighbour(Triangle n, int sideToUse)
    {
        if (neighbours.Contains(n))
            return false;

        if (vacantSides.Count == 0)
            return false;

        if (vacantSides.Contains(1))
        {
            switch (sideToUse)
            {
                case 1:
                    n.SetVertexA(vertexA);
                    n.SetVertexB(vertexB);
                    break;
                case 2:
                    n.SetVertexA(vertexA);
                    n.SetVertexC(vertexB);
                    break;
                case 3:
                    n.SetVertexB(vertexA);
                    n.SetVertexC(vertexB);
                    break;
            }
            vacantSides.Remove(1);
        }
        else if(vacantSides.Contains(2))
        {
            switch (sideToUse)
            {
                case 1:
                    n.SetVertexA(vertexA);
                    n.SetVertexB(vertexC);
                    break;
                case 2:
                    n.SetVertexA(vertexA);
                    n.SetVertexC(vertexC);
                    break;
                case 3:
                    n.SetVertexB(vertexA);
                    n.SetVertexC(vertexC);
                    break;
            }
            vacantSides.Remove(2);
        }
        else if (vacantSides.Contains(3))
        {
            switch (sideToUse)
            {
                case 1:
                    n.SetVertexA(vertexB);
                    n.SetVertexB(vertexC);
                    break;
                case 2:
                    n.SetVertexA(vertexB);
                    n.SetVertexC(vertexC);
                    break;
                case 3:
                    n.SetVertexB(vertexB);
                    n.SetVertexC(vertexC);
                    break;
            }
            vacantSides.Remove(3);
        }

        n.GetNeighbours().Add(this);
        n.vacantSides.Remove(sideToUse); //We have to remove the side we used from the new triangle's vacant sides.
        neighbours.Add(n);
        return true;
    }

    private int[] RandSides()
    {
        int[] sides = new int[2];
        int r = UnityEngine.Random.Range(0, 3) + 1;
        sides[0] = r; //We are basically picking a random side between 1, 2 and 3.
        while(sides[0] == r)
        {
            r = UnityEngine.Random.Range(0, 3) + 1;
        }
        sides[1] = r; //We have found our second side.
        return sides;
    }

    public List<int> GetVacantSides()
    {
        return vacantSides;
    }

    public List<Vector3> GetVertices()
    {
        List<Vector3> vertices = new List<Vector3>
        {
            vertexA,
            vertexB,
            vertexC
        };

        return vertices;
    }

    public List<Triangle> GetNeighbours()
    {
        return neighbours;
    }

    public Vector3 GetVertexA()
    {
        return vertexA;
    }

    public Vector3 GetVertexB()
    {
        return vertexB;
    }

    public Vector3 GetVertexC()
    {
        return vertexC;
    }

    public void SetVertexA(Vector3 vertexA)
    {
        this.vertexA = vertexA;
    }

    public void SetVertexB(Vector3 vertexB)
    {
        this.vertexB = vertexB;
    }

    public void SetVertexC(Vector3 vertexC)
    {
        this.vertexC = vertexC;
    }
}