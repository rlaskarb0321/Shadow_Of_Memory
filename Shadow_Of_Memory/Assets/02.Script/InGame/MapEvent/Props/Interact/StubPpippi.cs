using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StubPpippi : DialogEvent
{
    [Header("=== ppippi ===")]
    [SerializeField] private GameObject _realPpippi;
    //[SerializeField]  CampaignUI _campaignUI;

    [Header("=== Data ===")]
    [SerializeField] private PlayerMemory _player;
    [SerializeField] private InGameSaveLoad _inGameSaveLoad;

    private string _cult;
    private int _noCultCount; // 삐삐 데려가기 거절당한 횟수 카운트

    public override void Interaction(PlayerCtrl player)
    {
        if (_campaignUI._isDialogOn)
            return;

        _campaignUI.SetDialogOn(true, "Ppippi Carry", this);
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);

        float ppippiPos = _sr.transform.position.x;
        float playerPos = collision.transform.position.x;

        FlipSprite(ppippiPos, playerPos);
    }

    public override void DoDialogEvent(string eventContext)
    {
        _cult = eventContext;
        SelectYesOrNo();
        //dfdfdfd
    }

    public override void SelectYesOrNo()
    {
        switch (_cult)
        {
            case "동의":
                _realPpippi.SetActive(true);
                _sr.gameObject.SetActive(false);
                _player._isMeetPpippi = true;
                _inGameSaveLoad.SaveToServer(_player);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;

            case "거부":
                _noCultCount++;
                break;
        }
    }
}
