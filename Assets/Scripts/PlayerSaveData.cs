using System.Collections;
using System.Collections.Generic;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PlayerSaveData : MonoBehaviour
{
    private SaveData mydata = new SaveData();

    void Update()
    {
        PlayerPhysicData playerData = FindObjectOfType<PlayerController>().GetPlayerControllerData();
        //Debug.Log("torque" + playerData.Rotation);
        mydata.PlayerPhysicData = playerData;
        // mydata.Health = FindObjectOfType<HealthManager>().GetHealth();
        mydata.Health = HealthManager.health;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        mydata.highestSceneNumber = currentSceneIndex + 1;
    }

    void SetSaveGameManager(SaveData mydata)
    {
        Debug.Log("health " + mydata.Health);
        SaveGameManager.CurrentSaveData.PlayerPhysicData = mydata.PlayerPhysicData;
        SaveGameManager.CurrentSaveData.Health = mydata.Health;
        SaveGameManager.CurrentSaveData.highestSceneNumber = mydata.highestSceneNumber;

    }

    public void Save()
    {
        SetSaveGameManager(mydata);
        SaveGameManager.SaveGame();
        Debug.Log("save at: " + SaveGameManager.CurrentSaveData);
    }

    public void Load()
    {
        SaveGameManager.LoadGame();
        mydata = SaveGameManager.CurrentSaveData;
        FindObjectOfType<PlayerController>().SetPlayerPositionOnLoad(mydata.PlayerPhysicData);
        FindObjectOfType<HealthManager>().LoadHealth(mydata.Health);
    }



}




