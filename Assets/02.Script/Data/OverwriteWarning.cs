using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverwriteWarning : MonoBehaviour
{
    public int _index;

    public void DecideYesNo(bool isYes)
    {
        // 초기화 하겠습니다
        if (isYes)
        {
            string fileName = "Save" + _index.ToString();

            // 덮어쓰기로 결정하면 초기값으로 데이터 전환
            SaveData newData = new SaveData();
            SaveSystem.Save(newData, fileName);
            LoadingScene.LoadScene("Campaign", _index);
        }
        // 아니요 초기화 안 할래요
        else
        {
            gameObject.SetActive(false);
        }
    }
}
