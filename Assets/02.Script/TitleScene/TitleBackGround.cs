using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackGround : MonoBehaviour
{
    [SerializeField]
    private float _initDelaySec;
    [SerializeField]
    private GameObject _mainBackGround;

    [SerializeField]
    private bool _isAnyKeyInput;
    [SerializeField]  private bool _isRun;
    private StartSceneMgr _startSceneMgr;

    private void Awake()
    {
        _startSceneMgr = GetComponentInParent<StartSceneMgr>();
    }

    private void Update()
    {
        if (Input.anyKeyDown && !_isAnyKeyInput)
        {
            _isAnyKeyInput = true;
        }

        if (_isAnyKeyInput && !_isRun)
        {
            _isRun = true;
            StartCoroutine(_startSceneMgr.FadeInOutPanel(_initDelaySec, gameObject, _mainBackGround));
        }
    }
}
