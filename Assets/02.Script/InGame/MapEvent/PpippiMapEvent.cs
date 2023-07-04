using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpippiMapEvent : MapEvent
{
    [SerializeField] private SpriteRenderer _ppippiDummy;
    [SerializeField] private GameObject _conversationUI;

    [Header("=== Data ===")]
    [SerializeField] private PlayerMemory _player;
    [SerializeField] private InGameSaveLoad _inGameSaveLoad;

    public override void Interaction(PlayerCtrl player)
    {
        // 대화를 한다.
        // 대화에서 데려가기를 선택하면 값을 바꾸고 서버에 자동저장

        // 데려가기 선택 시
        //_player._isMeetPpippi = true;
        //_inGameSaveLoad.SaveToServer(_player);
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
}
