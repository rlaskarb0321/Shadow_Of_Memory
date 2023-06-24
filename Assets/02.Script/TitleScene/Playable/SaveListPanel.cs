using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveListPanel : MonoBehaviour
{
    [SerializeField] private GameObject _overwriteWarning;
    [SerializeField] private GameObject _hasNoDataWarning;

    // ������ ��ư Ŭ������ OnClick �̺�Ʈ �޼���
    public void OnClickNewGameList(int index)
    {
        string fileName = "Save" + index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";
        
        if (!File.Exists(filePath))
        {
            SaveData newData = new SaveData(Vector3.zero);
            SaveSystem.Save(newData, fileName);
            LoadingScene.LoadScene("Campaign");
        }
        else
        {
            // print("������ �̹� �����մϴ� �������?");
            _overwriteWarning.SetActive(true);
            _overwriteWarning.GetComponent<OverwriteWarning>()._index = index;
            return;
        }
    }

    // ������ ��ư Ŭ������ OnClick �̺�Ʈ �޼���
    public void OnClickSaveList(int index)
    {
        string fileName = "Save" + index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";

        if (File.Exists(filePath))
        {
            SaveData loadData = SaveSystem.Load(fileName);
            print("������ �ҷ����� ����");
        }
        else
        {
            bool isNoDataWarnActive = _hasNoDataWarning.activeSelf;
            if (isNoDataWarnActive)
            {
                _hasNoDataWarning.gameObject.SetActive(false);
                _hasNoDataWarning.gameObject.SetActive(true);
            }
            else
            {
                _hasNoDataWarning.gameObject.SetActive(true);
            }
        }
    }
}
