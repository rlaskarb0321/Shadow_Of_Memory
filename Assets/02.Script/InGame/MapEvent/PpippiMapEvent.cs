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
        // ��ȭ�� �Ѵ�.
        // ��ȭ���� �������⸦ �����ϸ� ���� �ٲٰ� ������ �ڵ�����

        // �������� ���� ��
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
