using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author:  Anthony Kolenic
 * Description:
 * Class to allow the passing of settings between classes
 * and scenes easily
 */ 

public class SettingsContainer
{
    public static bool trainingModeEnabled = false;
    public static int numberOfBots = 10;
    public static int numberOfTurns = 10;
    public static int mapWidth = 10;
    public static int mapHeight = 10;
}
