using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    /*
     * Static variables to be accessed from other classes when needed.
     */
    public static float WORLD_MIN_X = -20f;
    public static float WORLD_MIN_Y = 0f;
    public static float WORLD_MIN_Z = -20f;

    public static float WORLD_MAX_X = 20f;
    public static float WORLD_MAX_Y = 0f;
    public static float WORLD_MAX_Z = 20f;
    public OrigamiRobot robot;

    // Use this for initialization
    void Start ()
    {
        robot = new OrigamiRobot(0);
        robot.GenerateRobot();
    }
}
