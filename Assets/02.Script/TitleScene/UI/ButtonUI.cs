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
    [SerializeField] private AudioClip _mouseEnterSound;

    private AudioSource _audio;
    private Image _thisImg;

    private void Awake()
    {
        _thisImg = GetComponent<Image>();
        _audio = GetComponent<AudioSource>();
    }

    public override void OnPointerEnter()
    {
        if (_thisImg != null)
            _thisImg.sprite = _selectFonts;

        if (_selectMenu != null)
            _selectMenu.SetActive(true);

        if (_mouseEnterSound != null)
        {
            print("sound");
            _audio.PlayOneShot(_mouseEnterSound);
        }
    }

    public override void OnPointerExit()
    {
        if (_thisImg != null)
            _thisImg.sprite = _originFonts;

        if (_selectMenu != null)
            _selectMenu.SetActive(false);
    }
}
