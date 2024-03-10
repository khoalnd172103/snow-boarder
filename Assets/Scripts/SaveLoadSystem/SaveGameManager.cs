using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace SaveLoadSystem
{
    public static class SaveGameManager
    {
        public static SaveData CurrentSaveData = new SaveData();

        public const string SaveDirectory = "/SaveData/";
        public const string FileName = "SaveGame.sav";

        public static bool SaveGame()
        {
            var dir = Application.persistentDataPath + SaveDirectory;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string json = JsonUtility.ToJson(CurrentSaveData, true);
            File.WriteAllText(dir + FileName, json);

            GUIUtility.systemCopyBuffer = dir;

            return true;
        }

        public static void LoadGame()
        {
            string fullPath = Application.persistentDataPath + SaveDirectory + FileName;

            SaveData tempData = new SaveData();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                tempData = JsonUtility.FromJson<SaveData>(json);
            }
            else
            {
                Debug.LogError("Save file does not exist");
            }

            CurrentSaveData = tempData;
        }

        public static void DeleteSaveFile()
        {
            string saveFilePath = Application.persistentDataPath + SaveDirectory + FileName;

            // Check if the save file exists
            if (File.Exists(saveFilePath))
            {
                // Delete the save file
                File.Delete(saveFilePath);
            }
            else
            {
                Debug.LogError("Save file does not exist");
            }
        }

        public static bool DoesSaveFileExist()
        {
            string saveFilePath = Application.persistentDataPath + SaveDirectory + FileName;
            return File.Exists(saveFilePath);
        }
    }
}
