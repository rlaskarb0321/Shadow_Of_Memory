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

    private bool _isPausePanelOn;
    private bool _isMBoardOn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !ProductionMgr._isPlayProduction && !_isPausePanelOn)
        {
            OnOffMemoryBoardUI();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isMBoardOn)
            {
                OnOffMemoryBoardUI();
                return;
            }

            if (_isPausePanelOn)
            {
                OnOffPausePanelUI();
                return;
            }

            OnOffPausePanelUI();
        }
    }

    public void OnOffPausePanelUI()
    {
        _pauseBtn.SetActive(_pausePanel.activeSelf);
        _pausePanel.SetActive(!_pausePanel.activeSelf);
        _isPausePanelOn = _pausePanel.activeSelf;
    }

    public void OnOffMemoryBoardUI()
    {
        // 연출재생중인데 기억보드패널이 켜져있다면 끔
        if (ProductionMgr._isPlayProduction && _memoryBoardPanel.activeSelf)
        {
            _memoryBoardPanel.SetActive(false);
            _isMBoardOn = false;
            return;
        }


        // 현재 mBoard On/Off 상태의 반전값 대입
        _pauseBtn.SetActive(_memoryBoardPanel.activeSelf);
        _memoryBoardPanel.SetActive(!_memoryBoardPanel.activeSelf);
        _isMBoardOn = _memoryBoardPanel.activeSelf;
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
