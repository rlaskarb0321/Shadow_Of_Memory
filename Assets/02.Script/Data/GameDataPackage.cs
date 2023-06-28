using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 로딩씬에 있는 스크립트
public class GameDataPackage : MonoBehaviour
{
    public static GameData _gameData;
    public static int _index;

    // 인덱스 번째의 세이브 파일을 불러와서 _gameData에 저장시킴
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
