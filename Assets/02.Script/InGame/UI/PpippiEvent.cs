using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PpippiEvent : MonoBehaviour // 얘네들도 DialogEvent 객체를 받아야 할 것 같음
{
    [SerializeField] private Text _eventName;
    [SerializeField] private Text _eventIdx;

    public enum eMyParentObj { New, Old, };
    public eMyParentObj _pObj;
    private string _fileName;
    [HideInInspector] public PpippiEventList _ppippiEventList;

    public void SetEventValue(PpippiEventData data, PpippiEventList ppippiEventList)
    {
        _eventName.text = data._name;
        _eventIdx.text = data._idx.ToString();
        _fileName = data._fileName;
        _ppippiEventList = ppippiEventList;
    }

    public void SetParentObj(Transform tr, eMyParentObj pObj)
    {
        transform.SetParent(tr);
        transform.localPosition = Vector3.zero;
        _pObj = pObj;
    }

    public void OnClickEventList()
    {

    }
}
