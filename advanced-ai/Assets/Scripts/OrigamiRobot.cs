using UnityEngine;
using UnityEditor;

public class OrigamiRobot : ScriptableObject
{
    private Triangle[] parts;
    private int team { get; set; }

    public OrigamiRobot(int team)
    {
        this.team = team;
    }

    private void initialize()
    {

    }

    private Triangle[] generateRobot()
    {
        return parts;
    }
}