using UnityEngine;
using UnityEngine.UI;

// 캠페인 씬에 있는 UI들의 Active를 On/Off 하는 스크립트
public class CampaignUI : MonoBehaviour
{
    // SerializeField
    [Header("=== Memory Board ===")]
    [SerializeField] private GameObject _memoryBoardPanel;
    [SerializeField] private GameObject _collectUI;

    [Header("=== Pause ===")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseBtn;

    [Header("=== Conversation ===")]
    [SerializeField] private GameObject _ppippiEvent;
    [SerializeField] private GameObject _ppippi;
    public Dialog _dialog;

    // HideInInspector
    private DialogEvent _dialogEvent;
    private bool _isPausePanelOn;
    private bool _isMBoardOn;
    private bool _isPpippiEventOn;
    [HideInInspector] public bool _isDialogOn; // 대화가 시작되고 끝이났는지 판단하는 요소이기도 함

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

        // C키 눌렀을 때, 퍼즈패널이랑 메모리보드가 꺼져있으면 삐삐이벤트 킴
        if (Input.GetKeyDown(KeyCode.C) && !_isPausePanelOn && !_isMBoardOn)
        {
            SetPpippiEventActive(!_isPpippiEventOn);
            return;
        }

        // ESC키 눌렀을때 퍼즈패널, 대화창, 삐삐이벤트가 켜져있으면 끄고, 아니라면 퍼즈패널을 열음
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #region 23.07.03 피드백 후 정리될 코드들
            //if (_isMBoardOn)
            //{
            //    SetMemoryBoardActive(false);
            //    return;
            //}
            #endregion 23.07.03 피드백 후 정리될 코드들

            if (_isPpippiEventOn)
            {
                SetPpippiEventActive(false);
                return;
            }

            if (_isPausePanelOn)
            {
                SetPausePanelActive(false);
                return;
            }

            if (_isDialogOn)
            {
                SetDialogOn(false, "", _dialogEvent);
                return;
            }

            SetPausePanelActive(true);
        }
    }

    // value값에 맞는 퍼즈패널 액티브
    public void SetPausePanelActive(bool value)
    {
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

    // value값에 맞는 삐삐이벤트 액티브
    public void SetPpippiEventActive(bool value)
    {
        if (!_ppippi.gameObject.activeSelf)
        {
            print("삐삐가 없습니다");
            return;
        }

        _isPpippiEventOn = value;
        _ppippiEvent.SetActive(value);
    }

    // isTurnOn값에 맞는 대화창 액티브
    // fileName 값이 "" 가 아니면, 대화관련 csv 파일과 대화 이벤트 처리 담당 객체를 전달
    public void SetDialogOn(bool isTurnOn, string fileName = "", DialogEvent dialogEvent = null)
    {
        // 단순 ui 껐다 켰다하는 작업
        _dialogEvent = dialogEvent;
        _dialogEvent._isDialog = isTurnOn;
        _isDialogOn = isTurnOn;
        _dialog.gameObject.SetActive(isTurnOn);

        if (!fileName.Equals(""))
        {
            // 대화를 위한 파일과 대화 이벤트 객체를 전달하고 대화 시스템을 실행한다.
            _dialog.SetDialogFile(fileName, dialogEvent);
        }
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