using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenuFunctions : MonoBehaviour {
    Slider numOriBots;
    Slider numBattles;

    public void Start()
    {
        numBattles = GameObject.Find("Canvas/SettingObject/NumBattles").GetComponent<Slider>();
        numOriBots = GameObject.Find("Canvas/SettingObject/NumBots").GetComponent<Slider>();
        numOriBots.onValueChanged.AddListener(delegate { NumBotChanged(); });
        numBattles.onValueChanged.AddListener(delegate { NumBattlesChanged(); });
        GameObject.Find("Canvas/SettingObject/txtNumBots").GetComponent<Text>().text = "Number of Bots: " + (int)numOriBots.value;
        GameObject.Find("Canvas/SettingObject/txtNumBattles").GetComponent<Text>().text = "Number of Battles: " + (int)numBattles.value;
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

        SettingsContainer.trainingModeEnabled = mode;
        SettingsContainer.numberOfBots = numBots;
        SettingsContainer.numberOfTurns = numTurns;
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
}
