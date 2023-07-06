using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpippiMapEvent : DialogEvent
{
    [SerializeField] private SpriteRenderer _ppippiDummy;
    [SerializeField] private CampaignUI _campaignUI;

    [Header("=== Data ===")]
    [SerializeField] private PlayerMemory _player;
    [SerializeField] private InGameSaveLoad _inGameSaveLoad;

    private string _cult;

    public override void Interaction(PlayerCtrl player)
    {
        if (_campaignUI._isDialogOn)
            return;

        // 확장성을 고려한다면, SetDialogOn의 두번째 매개변수에 파일명을 다른걸 넣어주면된다.
        // 예를들어 삐삐가 여러번 거절당하면 Ppippi Carry에서 Ppippi Angry로 바꿔준다던지
        // 여러번 거절당함 판단은 이벤트로 관리한다.
        _campaignUI.SetDialogOn(true, "Ppippi Carry", this);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEventResearch") && _interactAlarm.activeSelf)
        {
            _interactAlarm.SetActive(false);
        }
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        float ppippiPos = _ppippiDummy.transform.position.x;
        float playerPos = collision.transform.position.x;

        if (collision.CompareTag("MapEventResearch") && !_interactAlarm.activeSelf)
            _interactAlarm.SetActive(true);

        if (ppippiPos - playerPos < 0.0f)
            _ppippiDummy.flipX = true;
        else if (ppippiPos - playerPos > 0.0f)
            _ppippiDummy.flipX = false;
    }

    public override void DoDialogEvent(string eventContext)
    {
        _cult = eventContext;
        SelectYesOrNo();
    }

    public override void SelectYesOrNo()
    {
        switch (_cult)
        {
            case "동의":
                print(_cult);
                break;

            case "거부":
                print(_cult);
                break;
        }
    }
}
