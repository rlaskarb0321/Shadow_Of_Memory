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
        // ���̺긮��Ʈ�� UI ������ ������ �ε����� �´� ���� �����ͼ� ����ȭ ������
        InitSaveListUI();
    }

    private void InitSaveListUI()
    {
        // ���Ͽ� ����
        string fileName = "Save" + _index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";

        // ������ �ִ��� Ȯ��
        if (File.Exists(filePath))
        {
            // ������ UI���� ���ְ�
            for (int i = 0; i < _showUI.Length; i++)
            {
                _showUI[i].SetActive(true);
            }

            // �����͸� Load�� ��, �ʱ�ȭ
            string saveFile = File.ReadAllText(filePath);
            SaveData loadData = JsonUtility.FromJson<SaveData>(saveFile);
            string date;
            string time;
            int collectCount;

            date = loadData._gameData._nowTime.Split(" ")[0];
            time = loadData._gameData._nowTime.Split(" ")[1];

            _showData.date.text = date;
            _showData.time.text = time;

            collectCount = loadData._gameData._currCollectCount;
            _showData.collectCount.text = $"{collectCount} ��";

            if (collectCount < ConstData._COLLECTLEVEL2)
            {
                _showData.characImg.sprite = _characterLevelImg[0];
            }
            else if (collectCount < ConstData._COLLECTLEVEL3)
            {
                _showData.characImg.sprite = _characterLevelImg[1];
            }
            else
            {
                _showData.characImg.sprite = _characterLevelImg[2];
            }
            _showData.characImg.SetNativeSize();

        }
    }
}