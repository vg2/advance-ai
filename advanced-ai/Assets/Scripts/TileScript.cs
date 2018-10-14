using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 * Author: Siphesihle Sithungu
 * Description: This is the game world.
 */
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

    GameObject[] upSide;
    GameObject[] downSide;
    List<OrigamiRobot> robots;

    // Use this for initialization
    void Start()
    {
        robots = new List<OrigamiRobot>();

        upSide = GameObject.FindGameObjectsWithTag("UpTag");
        downSide = GameObject.FindGameObjectsWithTag("DownTag");

        Debug.Log("Creating upSide robots...");
        for (int i = 0; i < upSide.Length; i++)
        {
            OrigamiRobot robot = new OrigamiRobot(0, 10, upSide[i].transform);
            robots.Add(robot);
        }

        Debug.Log("Creating downSide robots...");
        for (int i = 0; i < downSide.Length; i++)
        {
            OrigamiRobot robot = new OrigamiRobot(0, 10, downSide[i].transform);
            robots.Add(robot);
        }

        Debug.Log("Total number of robots: " + robots.Count);

        Dictionary<Triangle, List<Triangle>> links = robots[0].GetLinks();
        foreach(KeyValuePair<Triangle, List<Triangle>> kv in links)
        {
            Debug.Log("---------------------------------------Triangle--------------------------------------------");
            Debug.Log(kv.Key.GetVertexA() + " - " + kv.Key.GetVertexB() + " - " + kv.Key.GetVertexC());

            Debug.Log("---------------------------------------Neighbours--------------------------------------------");
            foreach (Triangle t in kv.Value)
            {
                Debug.Log(t.GetVertexA() + " - " + t.GetVertexB() + " - " + t.GetVertexC());
            }
        }
    }
}
