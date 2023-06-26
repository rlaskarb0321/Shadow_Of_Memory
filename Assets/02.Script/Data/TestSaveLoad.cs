using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveLoad : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            GameData saveData = new GameData(Vector3.one, new bool[ConstData._MEMORYCOUNT] { true, true, true, true, true, true }, 6);
            SaveData character = new SaveData(saveData);

            SaveSystem.Save(character, "Save1");
        }

        if (Input.GetKeyDown("l"))
        {
            SaveData loadData = SaveSystem.Load("Save1");
            print("Load Success");
        }
    }
}
