using UnityEngine;
using UnityEditor;

public class Triangle : ScriptableObject
{
    Coordinate a { get; set; }
    Coordinate b { get; set; }
    Coordinate c { get; set; }

    public Triangle(Coordinate a, Coordinate b, Coordinate c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
}