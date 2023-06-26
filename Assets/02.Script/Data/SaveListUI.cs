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
        string fileName = "Save" + _index.ToString();
        string filePath = SaveSystem.SavePath + fileName + ".json";

        if (File.Exists(filePath))
        {
            for (int i = 0; i < _showUI.Length; i++)
            {
                _showUI[i].SetActive(true);
            }

            // print(_index + " ÀÖ");
            SaveData loadData = SaveSystem.Load(fileName);

            _showData.date.text = loadData._playerPos.ToString();
            _showData.characImg.sprite = _characterLevelImg[0];
        }
    }
}