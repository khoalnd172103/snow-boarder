using System.Collections;
using System.Collections.Generic;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button LoadButton;
    public void PlayGame()
    {
        SaveGameManager.DeleteSaveFile();
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        if (SaveGameManager.DoesSaveFileExist())
        {
            SaveGameManager.LoadGame();
            SaveData mydata = SaveGameManager.CurrentSaveData;
            SceneManager.LoadSceneAsync(mydata.highestSceneNumber);
        }
    }

    void Update()
    {
        // Enable or disable the button based on the condition
        LoadButton.interactable = SaveGameManager.DoesSaveFileExist();
    }

}
