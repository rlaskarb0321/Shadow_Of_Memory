using System.IO;
using UnityEngine;

public class SaveSystem
{   
    public static string SavePath => Application.persistentDataPath + "/saves/";

    public static void Save(SaveData saveData, string saveFileName)
    {
        if (!Directory.Exists(SavePath))
        {
            // Debug.Log("���� ����");
            Directory.CreateDirectory(SavePath);
        }

        // Debug.Log(SceneManager.GetActiveScene().name);
        string saveJson = JsonUtility.ToJson(saveData);
        string saveFilePath = SavePath + saveFileName + ".json";
        File.WriteAllText(saveFilePath, saveJson);
        // Debug.Log("Save Success: " + saveFilePath);
    }

    public static SaveData Load(string saveFileName)
    {
        string saveFilePath = SavePath + saveFileName + ".json";
        string saveFile = File.ReadAllText(saveFilePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
        return saveData;
    }
}
