using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// �ε����� �ִ� ��ũ��Ʈ
public class GameDataPackage : MonoBehaviour
{
    public static GameData _gameData;
    public static int _index;

    // �ε��� ��°�� ���̺� ������ �ҷ��ͼ� _gameData�� �����Ŵ
    public static void SetData(int index)
    {
        string fileName = "Save" + index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";

        if (File.Exists(filePath))
        {
            SaveData loadData = SaveSystem.Load(fileName);
            _index = index;
            _gameData = loadData._gameData;
        }
    }
}
