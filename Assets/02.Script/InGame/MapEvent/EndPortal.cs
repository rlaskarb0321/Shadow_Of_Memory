using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MapEvent
{
    public float _fragMaxCount;

    [SerializeField]
    private Transform _nextPos;
    [SerializeField]
    private int _myLevel;

    public override void Interaction(PlayerCtrl player)
    {
        //if (player._playerCollectMemoryCount < _fragMaxCount)
        //{
        //    print("�� �ȸ���");
        //}
        //else
        //{
        //    print("�� ����");
        //    player.transform.position = _nextPos.position;
        //    player.SwitchPlayerCharacter(_myLevel);
        //}
    }
}
