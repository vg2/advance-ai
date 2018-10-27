using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTiles : MonoBehaviour
{
    //@Author Martin Rendani Mese
    //Render dynamic tiles of the simulation

    public int hexagon_scale;
    public GameObject[] hexagons;

    void Start()
    {
        hexagons = GameObject.FindGameObjectsWithTag("DownTag");

        if (hexagons != null)
        {
            int len = hexagons.Length;
            int diff = len - hexagon_scale;
            for (int i = 0; i < diff; i++)
            {
//hexagons[i].SetActive(false);
            }
        }
        hexagons = GameObject.FindGameObjectsWithTag("UpTag");

        if (hexagons != null)
        {
            int len = hexagons.Length;
            int diff = len - hexagon_scale;
            for (int i = 0; i < diff; i++)
            {
//hexagons[i].SetActive(false);
            }
        }

    }
    void Update()
    {

    }
}
