using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackGround : MonoBehaviour
{
    public bool _isAnyKeyInput;
    public bool _alreadyInput;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_alreadyInput)
        {
            return;
        }

        _isAnyKeyInput = Input.anyKey;
        if (_isAnyKeyInput && !_alreadyInput)
        {
            _audio.Play();
            _alreadyInput = true;
        }
    }
}
