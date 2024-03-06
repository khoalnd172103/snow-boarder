using System.Collections;
using System.Collections.Generic;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSaveData : MonoBehaviour
{
    private SaveData mydata = new SaveData();

    void Update()
    {

        PlayerPhysicData playerData = FindObjectOfType<PlayerController>().GetPlayerControllerData();
        Debug.Log("torque" + playerData.Rotation);
        mydata.PlayerPhysicData = playerData;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetSaveGameManager(mydata);
            SaveGameManager.SaveGame();
            Debug.Log("save at: " + SaveGameManager.CurrentSaveData);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SaveGameManager.LoadGame();
            mydata = SaveGameManager.CurrentSaveData;

            FindObjectOfType<PlayerController>().SetPlayerPositionOnLoad(mydata.PlayerPhysicData);

        }
    }

    void SetSaveGameManager(SaveData mydata)
    {
        SaveGameManager.CurrentSaveData.PlayerPhysicData = mydata.PlayerPhysicData;

    }



}




