using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveListPanel : MonoBehaviour
{
    [SerializeField] private GameObject _overwriteWarning;
    public GameObject _hasNoDataWarning;


    // 새게임 버튼 클릭관련 OnClick 이벤트 메서드
    public void OnClickNewGameList(int index)
    {
        // 파일의 위치를 찾아서
        string fileName = "Save" + index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";
        
        // 없으면 초기값으로 저장 후 캠페인씬을 열어줌
        if (!File.Exists(filePath))
        {
            SaveData newData = new SaveData();
            SaveSystem.Save(newData, fileName);
            LoadingScene.LoadScene("Campaign", index);
        }
        // 있으면 덮어씌움 여부를 묻는 UI 활성화
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
        // 파일의 위치를 찾아서
        string fileName = "Save" + index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";

        // 데이터가 있으면 불러오고 씬 이동
        if (File.Exists(filePath))
        {
            SaveData loadData = SaveSystem.Load(fileName);
            LoadingScene.LoadScene("Campaign", index);
        }
        // 없으면 없다는 경고문구 출력
        else
        {
            // 경고 문구의 UI애니메이션 관련 코드
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
