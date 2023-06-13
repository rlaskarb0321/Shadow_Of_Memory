using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StageMgr : MonoBehaviour
{
    public GameObject _playerObj;

    [Header("UI")]
    [SerializeField]
    private Image _fadeInOutPanel;    // 페이드인 페이드 아웃 이미지

    [SerializeField]
    private Text _timerText;

    public AudioSource _audio;

    [SerializeField]
    private GameObject _puzzleBackGround;

    [SerializeField]
    private int _maxFragCount;

    [HideInInspector]
    public static bool _isBlockInput;
    private PlayerCtrl _player;
    private bool _isEnd;
    private bool _isRun;
    private bool _isFadeEnd;

    private void Awake()
    {
        _player = _playerObj.GetComponent<PlayerCtrl>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_player._playerCollectMemoryCount == _maxFragCount && !_isRun)
        {
            _isEnd = true;
            _isRun = true;
        }

        if (_isEnd)
        {
            // StartCoroutine(FadeInFadeOut(1.0f, false));
            StartCoroutine(FadeIn(1.0f));
            _isEnd = false;
        }

        if (_isFadeEnd)
        {
            _puzzleBackGround.SetActive(true);
        }
    }

    public IEnumerator FadeInFadeOut(float fadeSpeed, bool needBlockInput)  // 화면 페이드인 페이드 아웃 해주는 함수
    {
        if (needBlockInput)
        {
            BlockInput(true);
        }

        _fadeInOutPanel.gameObject.SetActive(true);

        Color color = _fadeInOutPanel.color;

        float time = 0.0f;
        while (time <= 1f)
        {
            color.a = time;
            _fadeInOutPanel.color = color;
            time += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        time = 1.0f;
        while (time >= 0f)
        {
            color.a = time;
            _fadeInOutPanel.color = color;
            time -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        _isFadeEnd = true;
        _fadeInOutPanel.gameObject.SetActive(false);
        if (needBlockInput)
        {
            BlockInput(false);
        }

    }

    public static void BlockInput(bool value)
    {
        _isBlockInput = value;
    }

    public IEnumerator FadeIn(float fadeSpeed)  // 화면 페이드인 페이드 아웃 해주는 함수
    {
        _fadeInOutPanel.gameObject.SetActive(true);

        Color color = _fadeInOutPanel.color;
        float time = 0.0f;
        while (time <= 1f)
        {
            color.a = time;
            _fadeInOutPanel.color = color;
            time += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        _isFadeEnd = true;
    }
}
