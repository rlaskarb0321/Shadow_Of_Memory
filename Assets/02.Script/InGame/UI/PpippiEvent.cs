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
    public CampaignUI _campaignUI;

    public void SetEventValue(PpippiEventData data)
    {
        _eventName.text = data._name;
        _eventIdx.text = data._idx.ToString();
        _fileName = data._fileName;
    }

    public void SetParentObj(Transform tr, eMyParentObj pObj, CampaignUI campaignUI)
    {
        transform.SetParent(tr);
        transform.localPosition = Vector3.zero;
        _pObj = pObj;
        _campaignUI = campaignUI;
    }

    public void OnClickEventList()
    {
        _campaignUI.SetDialogOn(true, _fileName);
        _campaignUI.SetPpippiEventActive(false);
    }
}
