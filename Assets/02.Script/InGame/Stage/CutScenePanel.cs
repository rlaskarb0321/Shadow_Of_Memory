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

    private void Update()
    {
        _isInputSkip = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
    }
}
