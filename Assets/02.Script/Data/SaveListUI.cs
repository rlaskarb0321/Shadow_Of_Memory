using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DataShow
{
    public Image characImg;
    public Text date;
    public Text time;
    public Text collectCount;
}

public class SaveListUI : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private Sprite[] _characterLevelImg;
    [SerializeField] private GameObject[] _showUI;
    public DataShow _showData;

    private void OnEnable()
    {
        // 세이브리스트의 UI 값들을 데이터 인덱스에 맞는 값을 가져와서 동기화 시켜줌
        InitSaveListUI();
    }

    private void InitSaveListUI()
    {
        // 파일에 접근
        string fileName = "Save" + _index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";

        // 파일이 있는지 확인
        if (File.Exists(filePath))
        {
            // 보여줄 UI들을 켜주고
            for (int i = 0; i < _showUI.Length; i++)
            {
                _showUI[i].SetActive(true);
            }

            // 데이터를 Load한 뒤, 초기화
            string saveFile = File.ReadAllText(filePath);
            SaveData loadData = JsonUtility.FromJson<SaveData>(saveFile);
            string date;
            string time;

            date = loadData._nowTime.Split(" ")[0];
            time = loadData._nowTime.Split(" ")[1];

            _showData.date.text = date;
            _showData.time.text = time;

            _showData.characImg.sprite = _characterLevelImg[0];
            _showData.characImg.SetNativeSize();
        }
    }
}