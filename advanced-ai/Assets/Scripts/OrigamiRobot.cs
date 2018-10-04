using UnityEngine;
using UnityEditor;

public class OrigamiRobot
{
    private Triangle[] parts;
    private Vector3 position;
    private Vector3 orientation;
    private int team;
    public int fitness = 1000;

    public OrigamiRobot(int team)
    {
        this.team = team;
        parts = new Triangle[10];

        InitializeParts();
    }

    private void InitializeParts()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            Vector3 vertexA = new Vector3(Random.Range(TileScript.WORLD_MIN_X, TileScript.WORLD_MAX_X), 0, Random.Range(TileScript.WORLD_MIN_Z, TileScript.WORLD_MAX_Z));
            Vector3 vertexB = new Vector3(Random.Range(TileScript.WORLD_MIN_X, TileScript.WORLD_MAX_X), 0, Random.Range(TileScript.WORLD_MIN_Z, TileScript.WORLD_MAX_Z));
            Vector3 vertexC = new Vector3(Random.Range(TileScript.WORLD_MIN_X, TileScript.WORLD_MAX_X), 0, Random.Range(TileScript.WORLD_MIN_Z, TileScript.WORLD_MAX_Z));

            parts[i] = new Triangle(vertexA, vertexB, vertexC);
        }
    }

    public void GenerateRobot()
    {
        Debug.Log("-------------------Initial Origami Robots-------------------");
        foreach (Triangle t in parts)
        {
            Debug.Log(t.getVertexA() + ", " + t.getVertexB() + ", " + t.getVertexC());
        }
    }

    public int GetTeam()
    {
        return team;
    }

    public void SetTeam(int team)
    {
        this.team = team;
    }
}