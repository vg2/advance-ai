using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenuFunctions : MonoBehaviour {
    Slider numOriBots;
    Slider numBattles;
    Slider mapWidth;
    Slider mapHeight;

    public void Start()
    {
        numBattles = GameObject.Find("Canvas/SettingObject/NumBattles").GetComponent<Slider>();
        numOriBots = GameObject.Find("Canvas/SettingObject/NumBots").GetComponent<Slider>();

        mapWidth = GameObject.Find("Canvas/SettingObject/Width").GetComponent<Slider>();
        mapHeight = GameObject.Find("Canvas/SettingObject/Height").GetComponent<Slider>();

        numOriBots.onValueChanged.AddListener(delegate { NumBotChanged(); });
        numBattles.onValueChanged.AddListener(delegate { NumBattlesChanged(); });
        mapWidth.onValueChanged.AddListener(delegate { MapWidthChanged(); });
        mapHeight.onValueChanged.AddListener(delegate { MapHeightChanged(); });

        GameObject.Find("Canvas/SettingObject/txtNumBots").GetComponent<Text>().text = "Number of Bots: " + (int)numOriBots.value;
        GameObject.Find("Canvas/SettingObject/txtNumBattles").GetComponent<Text>().text = "Number of Battles: " + (int)numBattles.value;

        GameObject.Find("Canvas/SettingObject/txtWidth").GetComponent<Text>().text = "Map Width: " + (int)mapWidth.value;
        GameObject.Find("Canvas/SettingObject/txtHeight").GetComponent<Text>().text = "Map Height: " + (int)mapHeight.value;
    }

    public void StartSim()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitSim() 
    {
        Application.Quit();
    }

    public void UpdateSettings()
    {
        Toggle trainMode = GameObject.Find("Canvas/SettingObject/TrainMode").GetComponent<Toggle>();
        bool mode = trainMode.isOn;

        int numBots = (int)GameObject.Find("Canvas/SettingObject/NumBots").GetComponent<Slider>().value;

        int numTurns = (int)GameObject.Find("Canvas/SettingObject/NumBattles").GetComponent<Slider>().value;

        int width = (int)GameObject.Find("Canvas/SettingObject/Width").GetComponent<Slider>().value;

        int height = (int)GameObject.Find("Canvas/SettingObject/Height").GetComponent<Slider>().value;

        SettingsContainer.trainingModeEnabled = mode;
        SettingsContainer.numberOfBots = numBots;
        SettingsContainer.numberOfTurns = numTurns;
        SettingsContainer.mapWidth = width;
        SettingsContainer.mapHeight = height;
        Debug.Log("Settings Updated");
    }

    private void NumBotChanged()
    {
        GameObject.Find("Canvas/SettingObject/txtNumBots").GetComponent<Text>().text = "Number of Bots: " + (int)numOriBots.value;
        Debug.Log(numOriBots.value.ToString());
    }

    private void NumBattlesChanged()
    {
        GameObject.Find("Canvas/SettingObject/txtNumBattles").GetComponent<Text>().text = "Number of Battles: " + (int)numBattles.value;
        Debug.Log(numBattles.value.ToString());
    }

    private void MapWidthChanged()
    {
        GameObject.Find("Canvas/SettingObject/txtWidth").GetComponent<Text>().text = "Map Width: " + (int)mapWidth.value;
        Debug.Log(mapWidth.value.ToString());
    }

    private void MapHeightChanged()
    {
        GameObject.Find("Canvas/SettingObject/txtHeight").GetComponent<Text>().text = "Map Height: " + (int)mapHeight.value;
        Debug.Log(mapHeight.value.ToString());
    }
}
