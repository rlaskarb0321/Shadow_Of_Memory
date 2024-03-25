using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverwriteWarning : MonoBehaviour
{
    public int _index;

    public void DecideYesNo(bool isYes)
    {
        // �ʱ�ȭ �ϰڽ��ϴ�
        if (isYes)
        {
            string fileName = "Save" + _index.ToString();

            // ������ �����ϸ� �ʱⰪ���� ������ ��ȯ
            SaveData newData = new SaveData();
            SaveSystem.Save(newData, fileName);
            LoadingScene.LoadScene("Campaign", _index);
        }
        // �ƴϿ� �ʱ�ȭ �� �ҷ���
        else
        {
            gameObject.SetActive(false);
        }
    }
}
