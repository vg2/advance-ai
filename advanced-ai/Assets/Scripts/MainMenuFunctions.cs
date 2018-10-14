using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenuFunctions : MonoBehaviour {

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
}
