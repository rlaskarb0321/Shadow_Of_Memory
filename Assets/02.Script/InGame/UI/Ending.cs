using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject _fadePanel;

    private void OnEnable()
    {
        _fadePanel.SetActive(true);
        ProductionMgr._isPlayProduction = true;
    }

    public void OnClickToTitleBtn()
    {
        LoadingScene.LoadScene("StartScene");
    }
}
