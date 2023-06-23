using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragDetect : MonoBehaviour
{
    [SerializeField] private GameObject _collectFragUI;

    private Animator _uiAnim;
    private bool _isEnter;

    private void Awake()
    {
        _uiAnim = _collectFragUI.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Memory Fragment"))
            return;

        if (_uiAnim == null)
            return;

        _isEnter = true;
        _uiAnim.SetBool("isEnter", _isEnter);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Memory Fragment"))
            return;

        if (_uiAnim == null)
            return;

        _isEnter = false;
        _uiAnim.SetBool("isEnter", _isEnter);
    }
}
