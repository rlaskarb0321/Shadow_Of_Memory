using UnityEngine;

public class CampaignUI : MonoBehaviour
{
    // SerializeField
    [Header("=== Memory Board ===")]
    [SerializeField] private GameObject _memoryBoardPanel;
    [SerializeField] private GameObject _collectUI;

    [Header("=== Pause ===")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseBtn;

    [Header("=== Ppippi Conversation ===")]
    [SerializeField] private GameObject _ppippiDialog;
    [SerializeField] private GameObject _ppippi;

    // HideInInspector
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
            #region 23.07.03 피드백 후 정리될 코드들
            //if (_isMBoardOn)
            //    SetMemoryBoardActive(false);
            #endregion 23.07.03 피드백 후 정리될 코드들
        }

        if (Input.GetKeyDown(KeyCode.C) && !_isPausePanelOn && !_isMBoardOn)
        {
            SetPpippiDialogActive(!_isPpippiDialogOn);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #region 23.07.03 피드백 후 정리될 코드들
            //if (_isMBoardOn)
            //{
            //    SetMemoryBoardActive(false);
            //    return;
            //}
            #endregion 23.07.03 피드백 후 정리될 코드들

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
            //SetMemoryBoardActive(!value);
            SetPpippiDialogActive(!value);
        }

        _pauseBtn.SetActive(!value);
        _pausePanel.SetActive(value);
        _isPausePanelOn = value;
    }

    #region 23.07.03 피드백 후 정리될 코드들
    //// (구)삐삐와의 대화 선택지에서 대화 기록 보기 버튼을 눌렀을때
    //public void SetMemoryBoardActive(bool value)
    //{
    //    SetPpippiDialogActive(!value);
    //    _pauseBtn.SetActive(!value);
    //    _memoryBoardPanel.SetActive(value);
    //    _isMBoardOn = value;
    //}
    #endregion 23.07.03 피드백 후 정리될 코드들

    public void SetPpippiDialogActive(bool value)
    {
        if (!_ppippi.gameObject.activeSelf)
        {
            print("삐삐가 없습니다");
            return;
        }

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

    public void SetOffCollectUI()
    {
        _collectUI.GetComponent<Animator>().enabled = false;
    }
}