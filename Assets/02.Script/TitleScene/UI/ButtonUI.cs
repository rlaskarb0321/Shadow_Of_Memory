using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : UIInteractBase
{
    [SerializeField] private GameObject _selectMenu;
    [SerializeField] private Sprite _selectFonts;

    [Space(10.0f)]
    [SerializeField] private Sprite _originFonts;

    private Image _thisImg;

    private void Awake()
    {
        _thisImg = GetComponent<Image>();
    }

    public override void OnPointerEnter()
    {
        if (_thisImg != null)
            _thisImg.sprite = _selectFonts;

        if (_selectMenu != null)
            _selectMenu.SetActive(true);
    }

    public override void OnPointerExit()
    {
        if (_thisImg != null)
            _thisImg.sprite = _originFonts;

        if (_selectMenu != null)
            _selectMenu.SetActive(false);
    }
}
