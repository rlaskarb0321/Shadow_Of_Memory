using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageTimer : MonoBehaviour
{
    public Text text;
    public float _timer;
    private const float time = 90;

    private void Start()
    {
        _timer = time;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0.0f)
        {
            _timer = 0.0f;
        }

        text.text = ((int)_timer).ToString();
    }
}
