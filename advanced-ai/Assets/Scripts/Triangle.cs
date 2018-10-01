using UnityEngine;
using UnityEditor;

public class Triangle : ScriptableObject
{
    Coordinate a;
    Coordinate b;
    Coordinate c;

    public Triangle(Coordinate a, Coordinate b, Coordinate c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
}