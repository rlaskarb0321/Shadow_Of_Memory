using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveListPanel : MonoBehaviour
{
    [SerializeField] private GameObject _overwriteWarning;
    public GameObject _hasNoDataWarning;
    [SerializeField] private GameObject[] _saveList;

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
            //print("������ �ҷ����� �� �̵�");
            SaveData loadData = SaveSystem.Load(fileName);
            LoadingScene.LoadScene("Campaign", loadData);
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
