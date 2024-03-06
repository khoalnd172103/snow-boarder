using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        PlayerPrefs.SetInt("nextSceneNumber", 1);
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(int sceneIndex)
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Load the scene asynchronously
        SceneManager.LoadSceneAsync(sceneIndex);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe from the sceneLoaded event to prevent multiple subscriptions
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Explicitly call Awake() and Start() for all GameObjects in the scene
        foreach (GameObject go in scene.GetRootGameObjects())
        {
            go.BroadcastMessage("Awake", SendMessageOptions.DontRequireReceiver);
            go.BroadcastMessage("Start", SendMessageOptions.DontRequireReceiver);
        }
    }
}
