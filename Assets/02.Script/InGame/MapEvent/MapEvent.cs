using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapEvent : MonoBehaviour
{
    [SerializeField] protected GameObject _interactAlarm;

    public enum MapEventState { Open, Close, }

    public virtual void Interaction(PlayerCtrl player) { }

    protected virtual void Open() { }

    protected virtual void Close() { }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEventResearch") && !_interactAlarm.activeSelf)
        {
            _interactAlarm.SetActive(true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEventResearch") && _interactAlarm.activeSelf)
        {
            _interactAlarm.SetActive(false);
        }
    }
}
