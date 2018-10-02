using UnityEngine;
using UnityEditor;

public class Triangle
{
    /*
     * a, b and c are the triangle's vertices.
     */
    private Vector3 vertexA;
    private Vector3 vertexB;
    private Vector3 vertexC;

    public Triangle(Vector3 vertexA, Vector3 vertexB, Vector3 vertexC)
    {
        this.vertexA = vertexA;
        this.vertexB = vertexB;
        this.vertexC = vertexC;
    }

    public Vector3 getVertexA()
    {
        return vertexA;
    }

    public Vector3 getVertexB()
    {
        return vertexB;
    }

    public Vector3 getVertexC()
    {
        return vertexC;
    }

    public void setVertexA(Vector3 vertexA)
    {
        this.vertexA = vertexA;
    }

    public void setVertexB(Vector3 vertexB)
    {
        this.vertexB = vertexB;
    }

    public void setVertexC(Vector3 vertexC)
    {
        this.vertexC = vertexC;
    }
}