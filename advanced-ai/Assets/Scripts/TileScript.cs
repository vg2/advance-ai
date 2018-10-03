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

    GameObject[] upSide;
    GameObject[] downSide;

    // Use this for initialization
    void Start()
    {
        upSide = GameObject.FindGameObjectsWithTag("UpTag");
        downSide = GameObject.FindGameObjectsWithTag("DownTag");

        for (int i = 0; i < upSide.Length; i++)
        {
            OrigamiRobot robot = new OrigamiRobot(0, 10, upSide[i].transform);
            Triangle[] robotParts = robot.getBody();
        }
    }
}
