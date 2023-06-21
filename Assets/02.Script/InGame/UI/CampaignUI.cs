using UnityEngine;

public class CampaignUI : MonoBehaviour
{
    [Header("=== Memory Board ===")]
    [SerializeField]
    private GameObject _memoryBoardPanel;

    [Header("=== Pause ===")]
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private GameObject _pauseBtn;

    [Header("=== Ppippi Conversation ===")]
    [SerializeField]
    private GameObject _ppippiDialog;
    [SerializeField]
    private GameObject _ppippi;

    private bool _isPausePanelOn;
    private bool _isMBoardOn;
    private bool _isPpippiDialogOn;

    private void Update()
    {
        #region 23.06.20 메모리보드 열기 M키 -> 삐삐와의 이전 대화기록 보기로 이전
        //if (Input.GetKeyDown(KeyCode.M) && !ProductionMgr._isPlayProduction && !_isPausePanelOn)
        //{
        //    OnOffMemoryBoardUI();
        //    return;
        //}
        #endregion 23.06.20 메모리보드 열기 M키 -> 삐삐와의 이전 대화기록 보기로 이전

        if (ProductionMgr._isPlayProduction)
        {
            //if (_isPausePanelOn)
            //    SetPpippiDialogActive(false);

            if (_isMBoardOn)
                SetMemoryBoardActive(false);
        }

        if (Input.GetKeyDown(KeyCode.G) && !_isPausePanelOn && !_isMBoardOn)
        {
            SetPpippiDialogActive(!_isPpippiDialogOn);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isMBoardOn)
            {
                SetMemoryBoardActive(false);
                return;
            }

            if (_isPpippiDialogOn)
            {
                SetPpippiDialogActive(false);
                return;
            }

            if (_isPausePanelOn)
            {
                SetPausePanelActive(false);
                return;
            }

            SetPausePanelActive(true);
        }
    }

    public void SetPausePanelActive(bool value)
    {
        if (value == true)
        {
            SetMemoryBoardActive(!value);
            SetPpippiDialogActive(!value);
        }

        _pauseBtn.SetActive(!value);
        _pausePanel.SetActive(value);
        _isPausePanelOn = value;
    }

    public void SetMemoryBoardActive(bool value)
    {
        SetPpippiDialogActive(!value);
        _pauseBtn.SetActive(!value);
        _memoryBoardPanel.SetActive(value);
        _isMBoardOn = value;
    }

    public void SetPpippiDialogActive(bool value)
    {
        if (!_ppippi.gameObject.activeSelf)
            return;

        _isPpippiDialogOn = value;
        _ppippiDialog.SetActive(value);
    }

    public void OnGameExitBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }
}