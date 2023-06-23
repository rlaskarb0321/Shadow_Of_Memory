using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainBackGround : MonoBehaviour
{
    [Header("=== SaveList ===")]
    [SerializeField] private GameObject _saveListBtn;
    [SerializeField] private GameObject _saveListPanelObj;

    private bool _isDataExist;
    private Text _saveListText;
    private SaveListPanel _saveListPanel;

    private void Awake()
    {
        _saveListText = _saveListBtn.GetComponent<Text>();
        _saveListPanel = _saveListPanelObj.GetComponent<SaveListPanel>();
    }

    private void Start()
    {
        // ����� ���̺������� �ִ���
        _isDataExist = Directory.Exists(Application.persistentDataPath + "/saves/");

        // ������, SaveList��ư�� �ð������� ��Ȱ��ȭ
        if (!_isDataExist)
        {
            Color color = _saveListText.color;
            color.a = 0.5f;
            _saveListText.color = color;

            _saveListText.raycastTarget = false;
            _saveListBtn.GetComponent<Button>().interactable = false;
        }
    }

    public void OnSaveListClick(string name)
    {
        bool isSaveListActive = _saveListPanelObj.activeSelf;
        _saveListPanelObj.SetActive(!isSaveListActive);
        if (!isSaveListActive)
            _saveListPanel.SetPath(name);
    }

    public void OnCampaignBtnClick()
    {
        LoadingScene.LoadScene("Campaign");
    }

    public void OnExitGameBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}