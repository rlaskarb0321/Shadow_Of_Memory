using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject _interactAlarm;

    public enum MapEventState { Open, Close, }

    public virtual void Interaction(PlayerCtrl player) { }

    protected virtual void Open() { }

    protected virtual void Close() { }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEventResearch"))
        {
            print("F ��ȣ�ۿ�");
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEventResearch"))
        {
            print("��ȣ�ۿ� ����");
        }
    }
}
