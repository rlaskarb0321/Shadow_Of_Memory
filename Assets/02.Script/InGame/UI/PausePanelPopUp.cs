using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelPopUp : MonoBehaviour
{
    [SerializeField] private GameObject _gameInfo;

    public void OnClickInfoBtn()
    {
        bool isActive = _gameInfo.activeSelf;
        _gameInfo.SetActive(!isActive);
    }

    public void OnClickSettingBtn()
    {

    }

}
