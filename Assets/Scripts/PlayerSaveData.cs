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
            OnClickSaveButton();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            OnClickLoadButton();
        }
    }

    void SetSaveGameManager(SaveData mydata)
    {
        SaveGameManager.CurrentSaveData.PlayerPhysicData = mydata.PlayerPhysicData;

    }

    public void OnClickSaveButton()
    {
        SetSaveGameManager(mydata);
        SaveGameManager.SaveGame();
        Debug.Log("save at: " + SaveGameManager.CurrentSaveData);
    }

    public void OnClickLoadButton()
    {
        SaveGameManager.LoadGame();
        mydata = SaveGameManager.CurrentSaveData;
        FindObjectOfType<PlayerController>().SetPlayerPositionOnLoad(mydata.PlayerPhysicData);
    }



}




