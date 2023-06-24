using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveLoad : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            SaveData character = new SaveData(Vector3.zero);

            SaveSystem.Save(character, "Save1");
        }

        if (Input.GetKeyDown("l"))
        {
            SaveData loadData = SaveSystem.Load("Save1");
            print("Load Success");
        }
    }
}
