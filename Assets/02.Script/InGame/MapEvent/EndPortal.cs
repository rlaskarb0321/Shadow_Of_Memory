using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MapEvent
{
    public float _fragMaxCount;

    public override void Interaction(PlayerCtrl player)
    {
        if (player._playerCollectMemoryCount < _fragMaxCount)
        {
            print("�� �ȸ���");
        }
        else
        {
            print("�� ����");
        }
    }
}
