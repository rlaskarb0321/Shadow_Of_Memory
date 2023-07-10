using UnityEngine;
using UnityEngine.UI;

// ķ���� ���� �ִ� UI���� Active�� On/Off �ϴ� ��ũ��Ʈ
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
    [HideInInspector] public bool _isDialogOn; // ��ȭ�� ���۵ǰ� ���̳����� �Ǵ��ϴ� ����̱⵵ ��

    private void Update()
    {
        #region 23.06.20 �޸𸮺��� ���� MŰ -> �߻߿��� ���� ��ȭ��� ����� ����
        //if (Input.GetKeyDown(KeyCode.M) && !ProductionMgr._isPlayProduction && !_isPausePanelOn)
        //{
        //    OnOffMemoryBoardUI();
        //    return;
        //}
        #endregion 23.06.20 �޸𸮺��� ���� MŰ -> �߻߿��� ���� ��ȭ��� ����� ����

        if (ProductionMgr._isPlayProduction)
        {
            #region 23.07.03 �ǵ�� �� ������ �ڵ��
            //if (_isMBoardOn)
            //    SetMemoryBoardActive(false);
            #endregion 23.07.03 �ǵ�� �� ������ �ڵ��
        }

        // CŰ ������ ��, �����г��̶� �޸𸮺��尡 ���������� �߻��̺�Ʈ Ŵ
        if (Input.GetKeyDown(KeyCode.C) && !_isPausePanelOn && !_isMBoardOn)
        {
            SetPpippiEventActive(!_isPpippiEventOn);
            return;
        }

        // ESCŰ �������� �����г�, ��ȭâ, �߻��̺�Ʈ�� ���������� ����, �ƴ϶�� �����г��� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #region 23.07.03 �ǵ�� �� ������ �ڵ��
            //if (_isMBoardOn)
            //{
            //    SetMemoryBoardActive(false);
            //    return;
            //}
            #endregion 23.07.03 �ǵ�� �� ������ �ڵ��

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

    // value���� �´� �����г� ��Ƽ��
    public void SetPausePanelActive(bool value)
    {
        _pauseBtn.SetActive(!value);
        _pausePanel.SetActive(value);
        _isPausePanelOn = value;
    }

    #region 23.07.03 �ǵ�� �� ������ �ڵ��
    //// (��)�߻߿��� ��ȭ ���������� ��ȭ ��� ���� ��ư�� ��������
    //public void SetMemoryBoardActive(bool value)
    //{
    //    SetPpippiDialogActive(!value);
    //    _pauseBtn.SetActive(!value);
    //    _memoryBoardPanel.SetActive(value);
    //    _isMBoardOn = value;
    //}
    #endregion 23.07.03 �ǵ�� �� ������ �ڵ��

    // value���� �´� �߻��̺�Ʈ ��Ƽ��
    public void SetPpippiEventActive(bool value)
    {
        if (!_ppippi.gameObject.activeSelf)
        {
            print("�߻߰� �����ϴ�");
            return;
        }

        _isPpippiEventOn = value;
        _ppippiEvent.SetActive(value);
    }

    // isTurnOn���� �´� ��ȭâ ��Ƽ��
    // fileName ���� "" �� �ƴϸ�, ��ȭ���� csv ���ϰ� ��ȭ �̺�Ʈ ó�� ��� ��ü�� ����
    public void SetDialogOn(bool isTurnOn, string fileName = "", DialogEvent dialogEvent = null)
    {
        // �ܼ� ui ���� �״��ϴ� �۾�
        _dialogEvent = dialogEvent;
        _dialogEvent._isDialog = isTurnOn;
        _isDialogOn = isTurnOn;
        _dialog.gameObject.SetActive(isTurnOn);

        if (!fileName.Equals(""))
        {
            // ��ȭ�� ���� ���ϰ� ��ȭ �̺�Ʈ ��ü�� �����ϰ� ��ȭ �ý����� �����Ѵ�.
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