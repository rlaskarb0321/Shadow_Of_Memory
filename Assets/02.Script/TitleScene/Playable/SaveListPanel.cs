using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveListPanel : MonoBehaviour
{
    [SerializeField] private GameObject _overwriteWarning;
    [SerializeField] private GameObject _hasNoDataWarning;

    // 새게임 버튼 클릭관련 OnClick 이벤트 메서드
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
            // print("파일이 이미 존재합니다 덮어씌울까요?");
            _overwriteWarning.SetActive(true);
            _overwriteWarning.GetComponent<OverwriteWarning>()._index = index;
            return;
        }
    }

    // 저장목록 버튼 클릭관련 OnClick 이벤트 메서드
    public void OnClickSaveList(int index)
    {
        string fileName = "Save" + index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";

        if (File.Exists(filePath))
        {
            SaveData loadData = SaveSystem.Load(fileName);
            print("데이터 불러오기 성공");
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
