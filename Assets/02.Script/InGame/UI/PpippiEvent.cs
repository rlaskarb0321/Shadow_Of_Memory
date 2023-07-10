using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PpippiEvent : MonoBehaviour
{
    [SerializeField] private Text _eventName;
    [SerializeField] private Text _eventIdx;
    [SerializeField] private Text _isWatchingText;
    public ppippiEventData _eventData;

    public enum eMyParentObj { New, Old, };
    private eMyParentObj _pObj; // 이 스크립트를 가지는 리스트의 new, old 를 판단하기 위한 변수
    private CampaignUI _campaignUI; // ui패널의 온/오프 관리를 위해 객체 전달받을 변수
    private PpippiEventMgr _eventMgr; // 리스트 정렬 & 삐삐 머리위 알람 관리를 위한 객체 전달받을 변수

    public void SetEventValue(ppippiEventData data)
    {
        _eventData = data;

        _eventIdx.text = data._idx.ToString();
        _eventName.text = data._name;
        _isWatchingText.text = ConstData._isNotWatching;
    }

    public void SetParentObj(Transform tr, eMyParentObj pObj, CampaignUI campaignUI = null, PpippiEventMgr eventMgr = null)
    {
        if (campaignUI != null && _campaignUI == null)
            _campaignUI = campaignUI;

        if (eventMgr != null && _eventMgr == null)
            _eventMgr = eventMgr;

        if (pObj.Equals(eMyParentObj.Old))
            _eventMgr._ppippiOldEventList.Add(this);

        transform.SetParent(tr);
        transform.localPosition = Vector3.zero;
        _pObj = pObj;
    }

    public void OnClickEventList()
    {
        if (_pObj.Equals(eMyParentObj.New))
        {
            // 새삥이 클릭된것임, 삐삐의 알람을 꺼 주고 정렬도 시켜야한다.
            _eventMgr._ppippiAlarm.SetActive(false);
            this.SetParentObj(_eventMgr._oldEventItem.transform, eMyParentObj.Old);
        }

        // 대화 ui 켜주고, 삐삐이벤트 ui 꺼주고
        _campaignUI.SetDialogOn(true, _eventData._fileName);
        _campaignUI.SetPpippiEventActive(false);
        _eventData._isWatching = true;
        _isWatchingText.text = ConstData._isWatching;
    }
}
