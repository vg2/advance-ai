using UnityEngine;
using UnityEditor;

public class Coordinate : ScriptableObject
{
    private double x { get; set; }
    private double y { get; set; }
    private double z { get; set; }

    public Coordinate(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}