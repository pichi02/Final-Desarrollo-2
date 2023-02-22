using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveLoadPlayersDataSystem
{
    public static void SaveData<T>(T data, string path, string fileName)
    {
        string fullPath = Application.persistentDataPath + "/" + path + "/";

        bool existPath = Directory.Exists(fullPath);

        if (!existPath)
        {
            Directory.CreateDirectory(fullPath);
        }
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(fullPath + fileName + ".json", json);
    }

    public static T LoadData<T>(string path, string fileName)
    {
        string fullPath = Application.persistentDataPath + "/" + path + "/" + fileName + ".json";
        Debug.Log(fullPath);
        if (File.Exists(fullPath))
        {
            string textJson = File.ReadAllText(fullPath);
            var obj = JsonUtility.FromJson<T>(textJson);
            return obj;
        }
        else
        {
            return default;
        }

    }
}
