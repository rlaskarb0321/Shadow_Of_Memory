using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PpippiEvent : MonoBehaviour
{
    [SerializeField] private Text _eventName;
    [SerializeField] private Text _eventIdx;

    public void SetEventValue(PpippiEventData data)
    {
        _eventName.text = data._name;
        _eventIdx.text = data._idx.ToString();
    }
}
