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
        Debug.Log("A");
        numOriBots = GameObject.Find("Canvas/SettingObject/NumBots").GetComponent<Slider>();

        numBattles = GameObject.Find("Canvas/SettingObject/NumBattles").GetComponent<Slider>();
        numOriBots.onValueChanged.AddListener(delegate { NumBotChanged(); });
        numBattles.onValueChanged.AddListener(delegate { NumBattlesChanged(); });
        int numBots = (int)GameObject.Find("Canvas/SettingObject/NumBots").GetComponent<Slider>().value;
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

        int numBots = (int)this.numOriBots.value;

        int numTurns = (int)this.numBattles.value;

        SettingsContainer.trainingModeEnabled = mode;
        SettingsContainer.numberOfBots = numBots;
        SettingsContainer.numberOfTurns = numTurns;
        Debug.Log("Settings Updated");
    }

    private void NumBotChanged()
    {
        Debug.Log(numOriBots.value.ToString());
    }

    private void NumBattlesChanged()
    {
        Debug.Log(numBattles.value.ToString());
    }
}
