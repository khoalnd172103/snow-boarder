using System.Collections;
using System.Collections.Generic;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgame : MonoBehaviour
{
     public void PlayGame()
    {
        SaveGameManager.DeleteSaveFile();
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
