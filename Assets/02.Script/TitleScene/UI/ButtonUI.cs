using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : UIInteractBase
{
    [Header("=== Selected ===")]
    [SerializeField] private GameObject _selectMenu;
    [SerializeField] private Sprite _selectFonts;

    [Header("=== Origin ===")]
    [SerializeField] private Sprite _originFonts;

    [Header("=== Sound ===")]
    [SerializeField] private AudioClip _pointerEnterSound;

    private AudioSource _audio;
    private Image _thisImg;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _thisImg = GetComponent<Image>();
    }

    public override void OnPointerEnter()
    {
        if (_thisImg != null)
            _thisImg.sprite = _selectFonts;

        if (_selectMenu != null)
            _selectMenu.SetActive(true);

        if (_pointerEnterSound != null)
            _audio.PlayOneShot(_pointerEnterSound);
    }

    public override void OnPointerExit()
    {
        if (_thisImg != null)
            _thisImg.sprite = _originFonts;

        if (_selectMenu != null)
            _selectMenu.SetActive(false);
    }
}
