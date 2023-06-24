using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverwriteWarning : MonoBehaviour
{
    public int _index;

    public void DecideYesNo(bool isYes)
    {
        if (isYes)
        {
            string fileName = "Save" + _index.ToString();

            SaveData newData = new SaveData(Vector3.one); // 테스트를 위해 Vector3.one
            SaveSystem.Save(newData, fileName);
            LoadingScene.LoadScene("Campaign");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
