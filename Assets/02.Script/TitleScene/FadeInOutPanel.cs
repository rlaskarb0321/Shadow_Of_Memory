using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutPanel : MonoBehaviour
{
    public float _colorAlpha;
    private Image _thisImg;

    private void OnEnable()
    {
        _thisImg = GetComponent<Image>();
    }

    // 페이드 인하는 함수
    public IEnumerator FadeIn(float fadeSpeed)
    {
        Color color = _thisImg.color;
        float time = 0.0f;

        while (time <= 1.0f)
        {
            _colorAlpha = time;
            color.a = time;
            _thisImg.color = color;
            time += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    // 페이드 아웃하는 함수
    public IEnumerator FadeOut(float fadeSpeed)
    {
        Color color = _thisImg.color;
        float time = 1.0f;

        while (time >= 0.0f)
        {
            _colorAlpha = time;
            color.a = time;
            _thisImg.color = color;
            time -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        gameObject.SetActive(false);
    }

    // 페이드 인 ~ 기다림 ~ 페이드 아웃하는 함수
    public IEnumerator FadeInAndOut(float fadeSpeed, float fadeDelay = 0.065f)
    {
        yield return StartCoroutine(FadeIn(fadeSpeed));

        yield return new WaitForSeconds(fadeDelay);

        yield return StartCoroutine(FadeOut(fadeSpeed));
    }
}
