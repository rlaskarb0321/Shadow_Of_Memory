using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignUI : MonoBehaviour
{
    [Header("=== Memory Board ===")]
    [SerializeField]
    private GameObject _memoryBoardPanel;
    public GameObject[] _memoryPieces; 

    [Header("=== Pause ===")]
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private GameObject _pauseBtn;

    [Header("=== Ppippi Conversation ===")]
    [SerializeField]
    private GameObject _ppippiDialog;

    private bool _isPausePanelOn;
    private bool _isMBoardOn;
    private bool _isPpippiDialogOn;

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
            SetPpippiDialogActive(false);
            SetMemoryBoardActive(false);
            return;
        }

        if (Input.GetKeyDown(KeyCode.G) && !_isPausePanelOn)
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

            if (_isPausePanelOn)
            {
                SetPausePanelActive(false);
                return;
            }

            if (_isPpippiDialogOn)
            {
                SetPpippiDialogActive(false);
                return;
            }


            if (_isPausePanelOn)
                SetPausePanelActive(false);
            else
                SetPausePanelActive(true);
        }
    }

    public void SetPausePanelActive(bool value)
    {
        //_pauseBtn.SetActive(_pausePanel.activeSelf);
        //_pausePanel.SetActive(!_isPausePanelOn);
        //_isPausePanelOn = _pausePanel.activeSelf;

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
        // ����������ε� ��ﺸ���г��� �����ִٸ� ��
        //if (ProductionMgr._isPlayProduction && _memoryBoardPanel.activeSelf)
        //{
        //    _memoryBoardPanel.SetActive(false);
        //    _isMBoardOn = false;
        //    return;
        //}

        // ���� mBoard On/Off ������ ������ ����
        _pauseBtn.SetActive(!value);
        _memoryBoardPanel.SetActive(value);
        _isMBoardOn = value;
    }

    public void SetPpippiDialogActive(bool value)
    {
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
