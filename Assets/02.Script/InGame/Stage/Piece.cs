using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public float _speed;
    public bool _isEnd;

    private Image _thisImg;

    private void Awake()
    {
        _thisImg = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(DrawnPieces());
    }

    public IEnumerator DrawnPieces()
    {
        Color color = _thisImg.color;
        float time = 0.0f;
        while (time <= 1.0f)
        {
            color.a = time;
            _thisImg.color = color;
            time += Time.deltaTime;
            yield return null;
        }

        _isEnd = true;
    }
}
