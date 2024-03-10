using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        PlayerPrefs.SetInt("highestSceneNumber", 1);
        // PlayerPrefs.SetInt("nextSceneNumber", 1);
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
