using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveListPanel : MonoBehaviour
{
    [SerializeField] private GameObject _overwriteWarning;
    public GameObject _hasNoDataWarning;


    // ������ ��ư Ŭ������ OnClick �̺�Ʈ �޼���
    public void OnClickNewGameList(int index)
    {
        // ������ ��ġ�� ã�Ƽ�
        string fileName = "Save" + index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";
        
        // ������ �ʱⰪ���� ���� �� ķ���ξ��� ������
        if (!File.Exists(filePath))
        {
            SaveData newData = new SaveData();
            SaveSystem.Save(newData, fileName);
            LoadingScene.LoadScene("Campaign", index);
        }
        // ������ ����� ���θ� ���� UI Ȱ��ȭ
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
        // ������ ��ġ�� ã�Ƽ�
        string fileName = "Save" + index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";

        // �����Ͱ� ������ �ҷ����� �� �̵�
        if (File.Exists(filePath))
        {
            SaveData loadData = SaveSystem.Load(fileName);
            LoadingScene.LoadScene("Campaign", index);
        }
        // ������ ���ٴ� ����� ���
        else
        {
            // ��� ������ UI�ִϸ��̼� ���� �ڵ�
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
