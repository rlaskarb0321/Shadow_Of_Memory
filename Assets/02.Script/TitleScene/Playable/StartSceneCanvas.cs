using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneCanvas : MonoBehaviour
{
    [Header("BackGrounds")]
    [SerializeField]
    private GameObject _titleBackGround;
    [SerializeField]
    private GameObject _mainBackGround;

    [Header("BackGround Child")]
    public GameObject _titleChild;
    public GameObject _mainChild;

    [Header("Panel")]
    [SerializeField]
    private GameObject _fadePanelObj;

    private FadeInOutPanel _fadePanel;
    public float _fadeAlpha;
    private TitleBackGround _title;
    private MainBackGround _main;

    private void Awake()
    {
        _fadePanel = _fadePanelObj.GetComponent<FadeInOutPanel>();
        _title = _titleBackGround.GetComponent<TitleBackGround>();
        _main = _mainBackGround.GetComponent<MainBackGround>();
    }

    private void Update()
    {
        _fadeAlpha = _fadePanel._colorAlpha;

        if (_titleChild.activeSelf && _title._alreadyInput)
        {
            ManageTitle();
        }

        if (_mainChild.activeSelf)
        {
            ManageMain();
        }
    }

    private void ManageTitle()
    {
        if (!_fadePanelObj.activeSelf)
        {
            _fadePanelObj.SetActive(true);
            StartCoroutine(_fadePanel.FadeInAndOut(1.5f, 1.5f));
        }

        if (_fadeAlpha >= 0.9f)
        {
            _mainChild.gameObject.SetActive(true);
            _titleChild.gameObject.SetActive(false);
        }
    }

    private void ManageMain()
    {

    }
}
