using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScenePanel : MonoBehaviour
{
    [SerializeField]
    private Image[] _cutSceneImgs;

    [SerializeField]
    private float _nextSceneSpeed;

    private bool _isInputSkip;

    private void Start()
    {
        StartCoroutine(ShowCutScene());
    }

    private void Update()
    {
        _isInputSkip = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
    }

    private IEnumerator ShowCutScene()
    {
        StageMgr.BlockInput(true);

        yield return new WaitForSeconds(1.0f);

        int index = 0;
        while (index < _cutSceneImgs.Length)
        {
            _cutSceneImgs[index].gameObject.SetActive(true);
            Color color = _cutSceneImgs[index].color;

            float time = 0.0f;
            while (time <= 1f)
            {
                if (_isInputSkip)
                {
                    time = 1.0f;
                    _isInputSkip = false;
                }
                color.a = time;
                _cutSceneImgs[index].color = color;
                time += Time.deltaTime * 0.6f;
                yield return null;
            }

            index++;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        index = 0;
        while (index < _cutSceneImgs.Length)
        {
            Color color = _cutSceneImgs[index].color;

            float time = 1.0f;
            while (time > 0.0f)
            {
                if (_isInputSkip)
                {
                    time = 0.0f;
                    _isInputSkip = false;
                }
                color.a = time;
                _cutSceneImgs[index].color = color;
                time -= Time.deltaTime * 0.6f;
                yield return null;
            }

            index++;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        StageMgr.BlockInput(false);
        gameObject.SetActive(false);
    }
}
