using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoImg : MonoBehaviour
{
    public GameObject _timerObj;

    private Image _thisImg;
    private StageTimer _timer;
    private bool _isInputSkip;

    private void Awake()
    {
        _thisImg = GetComponent<Image>();
        _timer = _timerObj.GetComponent<StageTimer>();
    }

    private void Start()
    {
        StartCoroutine(OnDisableEffect());
    }

    private void Update()
    {
        _isInputSkip = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
    }

    private IEnumerator OnDisableEffect()
    {
        StageMgr.BlockInput(true);
        _thisImg.gameObject.SetActive(true);

        Color color = _thisImg.color;
        float time = 0.0f;
        while (time <= 1f)
        {
            if (_isInputSkip)
            {
                time = 1.0f;
                _isInputSkip = false;
            }
            color.a = time;
            _thisImg.color = color;
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        color = _thisImg.color;
        time = 1.0f;

        while (time > 0.0f)
        {
            if (_isInputSkip)
            {
                time = 0.0f;
                _isInputSkip = false;
            }
            color.a = time;
            _thisImg.color = color;
            time -= Time.deltaTime * 0.6f;
            yield return null;
        }

        //_timer._startOk = true;
        StageMgr.BlockInput(false);
    }
}
