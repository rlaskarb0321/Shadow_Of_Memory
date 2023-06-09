using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapEvent : MonoBehaviour
{
    public enum MapEventState { Open, Close, }

    public virtual void Interaction(PlayerCtrl player) { }

    protected virtual void Open() { }

    protected virtual void Close() { }
}
