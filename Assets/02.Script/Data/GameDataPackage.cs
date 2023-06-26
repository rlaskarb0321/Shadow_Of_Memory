using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataPackage : MonoBehaviour
{
    public static GameData _gameData;
    public static int _index;

    public static void SetData(int index)
    {
        string fileName = "Save" + index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";

        // �����Ͱ� ������ �ҷ����� �� �̵�
        if (File.Exists(filePath))
        {
            SaveData loadData = SaveSystem.Load(fileName);
            _index = index;
            _gameData = loadData._gameData;
        }
    }
}
