using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PpippiEvent : MonoBehaviour // 얘네들도 DialogEvent 객체를 받아야 할 것 같음
{
    [SerializeField] private Text _eventName;
    [SerializeField] private Text _eventIdx;

    public enum eMyParentObj { New, Old, };
    private eMyParentObj _pObj;
    private string _fileName;
    private CampaignUI _campaignUI;
    private PpippiEventMgr _eventMgr;

    public void SetEventValue(PpippiEventData data)
    {
        _eventName.text = data._name;
        _eventIdx.text = data._idx.ToString();
        _fileName = data._fileName;
    }

    public void SetParentObj(Transform tr, eMyParentObj pObj, CampaignUI campaignUI, PpippiEventMgr eventMgr)
    {
        transform.SetParent(tr);
        transform.localPosition = Vector3.zero;
        _pObj = pObj;
        _campaignUI = campaignUI;
        _eventMgr = eventMgr;
    }

    public void OnClickEventList()
    {
        if (_pObj.Equals(eMyParentObj.New))
        {
            // 새삥이 클릭된것임
            _eventMgr._ppippiAlarm.SetActive(false);
        }

        _campaignUI.SetDialogOn(true, _fileName);
        _campaignUI.SetPpippiEventActive(false);
    }
}
