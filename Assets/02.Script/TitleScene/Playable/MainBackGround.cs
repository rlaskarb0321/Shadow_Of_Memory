using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainBackGround : MonoBehaviour
{
    [Header("=== Save List ===")]
    [SerializeField] private GameObject _saveListBtn;
    [SerializeField] private GameObject _saveListPanelObj;
    [SerializeField] private bool _isSaveListPanelOn;

    [Header("=== New Game === ")]
    [SerializeField] private GameObject _newGameBtn;
    [SerializeField] private GameObject _newGamePanelObj;
    [SerializeField] private bool _isNewGamePanelOn;

    private bool _isDataExist;
    private Text _saveListText;
    private SaveListPanel _saveListPanel;
    private SaveListPanel _newGamePanel;
    private Button _saveListBtnComponent;

    private void Awake()
    {
        _saveListText = _saveListBtn.GetComponent<Text>();
        _saveListBtnComponent = _saveListBtn.GetComponent<Button>();

        _newGamePanel = _newGamePanelObj.GetComponent<SaveListPanel>();
        _saveListPanel = _saveListPanelObj.GetComponent<SaveListPanel>();
    }

    private void Start()
    {
        // 저장된 세이브폴더가 있는지확인후, 값에따라 SaveListBtn 시각적 활성화/비활성화
        _isDataExist = Directory.Exists(Application.persistentDataPath + "/saves/");
        IsSaveDataExist(_isDataExist);

    }

    private void Update()
    {
        _isNewGamePanelOn = _newGamePanelObj.activeSelf;
        _isSaveListPanelOn = _saveListPanelObj.activeSelf;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isNewGamePanelOn)
            {
                OnOffDataPanel("NewGame");
                return;
            }

            if (_isSaveListPanelOn)
            {
                OnOffDataPanel("SaveList");
                return;
            }
        }
    }

    public void OnOffDataPanel(string panelName)
    {
        switch (panelName)
        {
            case "NewGame":
                //bool isNewGamePanelOn = _newGamePanelObj.activeSelf;
                //_newGamePanelObj.SetActive(!isNewGamePanelOn);

                //_isNewGamePanelOn = _newGamePanelObj.activeSelf;
                _newGamePanelObj.SetActive(!_isNewGamePanelOn);
                break;

            case "SaveList":
                //bool isSaveListPanelOn = _saveListPanelObj.activeSelf;
                //_saveListPanel._hasNoDataWarning.SetActive(false);
                //_saveListPanelObj.SetActive(!isSaveListPanelOn);

                //_isSaveListPanelOn = _saveListPanelObj.activeSelf;
                _saveListPanel._hasNoDataWarning.SetActive(false);
                _saveListPanelObj.SetActive(!_isSaveListPanelOn);
                break;
        }
    }

    //public void OnCampaignBtnClick()
    //{
    //    LoadingScene.LoadScene("Campaign");
    //}

    public void OnExitGameBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void IsSaveDataExist(bool value)
    {
        Color color = _saveListText.color;
        bool isRayCastOn;
        bool isInteractable;

        if (value == false)
            color.a = 0.5f;
        else
            color.a = 1.0f;

        isRayCastOn = value;
        isInteractable = value;
        _saveListText.color = color;
        _saveListText.raycastTarget = isRayCastOn;
        _saveListBtnComponent.interactable = isInteractable;
    }
}