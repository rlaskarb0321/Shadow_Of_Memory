using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// 이 스크립트에서 newList, oldList 값 처리를 해야한다.
public class PpippiEventMgr : MonoBehaviour
{
    [Header("=== Event Item ===")]
    public GameObject _newEventItem;
    public GameObject _oldEventItem;
    public Dropdown _orderDropDown;
    [Space(5.0f)] [SerializeField] private CampaignUI _campaignUI;

    [Header("=== Ppippi ===")]
    public GameObject _ppippiAlarm;
    [SerializeField] private GameObject _ppippi;

    [Space(10.0f)] [SerializeField] private GameObject _eventListPrefabs;
    private enum eOrderBy { IndexUp, IndexDown, NameUp, NameDown, Watching, NotWatching }
    public List<PpippiEvent> _ppippiOldEventList;

    private void Start()
    {
        _ppippiOldEventList = new List<PpippiEvent>();
    }

    public void CreateNewList(ppippiEventData data)
    {
        if (_ppippi.activeSelf && !_ppippiAlarm.activeSelf)
        {
            _ppippiAlarm.SetActive(true);
        }

        PpippiEvent eventList = Instantiate(_eventListPrefabs, Vector3.zero, Quaternion.identity).GetComponent<PpippiEvent>();

        // 강조 Event 항목에 값이 이미 있다면, 이미 있던 값을 oldEvent 항목으로 옮기고, 새로 들어온 값이 강조 Event로 들어간다.
        if (_newEventItem.transform.childCount != 0)
        {
            PpippiEvent currNewEvent = _newEventItem.transform.GetChild(0).GetComponent<PpippiEvent>();

            currNewEvent.SetParentObj(_oldEventItem.transform, PpippiEvent.eMyParentObj.Old, _campaignUI, this);
            eventList.SetEventValue(data);
            eventList.SetParentObj(_newEventItem.transform, PpippiEvent.eMyParentObj.New, _campaignUI, this);
        }
        // 강조 Event 항목에 값이 없다면, 새로 들어온 값이 강조 Event로 들어간다.
        else
        {
            eventList.SetEventValue(data);
            eventList.SetParentObj(_newEventItem.transform, PpippiEvent.eMyParentObj.New, _campaignUI, this);
        }

        // 옮기면서, 정렬 기준값을 참조하여 재 정렬후 나열한다.
        OrderByDropDownValue();
        eventList.gameObject.name = eventList._eventData._name;
    }

    public void OrderByDropDownValue()
    {
        List<PpippiEvent> orderEventList = _ppippiOldEventList.ToList();

        switch ((eOrderBy)_orderDropDown.value)
        {
            case eOrderBy.IndexUp:
                orderEventList = orderEventList.OrderBy(x => x._eventData._idx).ToList();
                for (int i = 0; i < orderEventList.Count; i++)
                {
                    for (int j = 0; j < _ppippiOldEventList.Count; j++)
                    {
                        if (orderEventList[i]._eventData._idx.Equals(_ppippiOldEventList[j]._eventData._idx))
                        {
                            _ppippiOldEventList[j].transform.SetSiblingIndex(i);
                            break;
                        }
                    }
                }
                break;

            case eOrderBy.IndexDown:
                orderEventList = orderEventList.OrderByDescending(x => x._eventData._idx).ToList();
                for (int i = 0; i < orderEventList.Count; i++)
                {
                    for (int j = 0; j < _ppippiOldEventList.Count; j++)
                    {
                        if (orderEventList[i]._eventData._idx.Equals(_ppippiOldEventList[j]._eventData._idx))
                        {
                            _ppippiOldEventList[j].transform.SetSiblingIndex(i);
                            break;
                        }
                    }
                }
                break;

            case eOrderBy.NameUp:
                orderEventList = orderEventList.OrderBy(x => x._eventData._name).ToList();
                for (int i = 0; i < orderEventList.Count; i++)
                {
                    for (int j = 0; j < _ppippiOldEventList.Count; j++)
                    {
                        if (orderEventList[i]._eventData._name.Equals(_ppippiOldEventList[j]._eventData._name))
                        {
                            _ppippiOldEventList[j].transform.SetSiblingIndex(i);
                            break;
                        }
                    }
                }
                break;

            case eOrderBy.NameDown:
                orderEventList = orderEventList.OrderByDescending(x => x._eventData._name).ToList();
                for (int i = 0; i < orderEventList.Count; i++)
                {
                    for (int j = 0; j < _ppippiOldEventList.Count; j++)
                    {
                        if (orderEventList[i]._eventData._name.Equals(_ppippiOldEventList[j]._eventData._name))
                        {
                            _ppippiOldEventList[j].transform.SetSiblingIndex(i);
                            break;
                        }
                    }
                }
                break;

            case eOrderBy.Watching:
                orderEventList = orderEventList.OrderByDescending(x => x._eventData._isWatching).ToList();
                for (int i = 0; i < orderEventList.Count; i++)
                {
                    for (int j = 0; j < _ppippiOldEventList.Count; j++)
                    {
                        if (orderEventList[i]._eventData._name.Equals(_ppippiOldEventList[j]._eventData._name))
                        {
                            _ppippiOldEventList[j].transform.SetSiblingIndex(i);
                            break;
                        }
                    }
                }
                break;

            case eOrderBy.NotWatching:
                orderEventList = orderEventList.OrderBy(x => x._eventData._isWatching).ToList();
                for (int i = 0; i < orderEventList.Count; i++)
                {
                    for (int j = 0; j < _ppippiOldEventList.Count; j++)
                    {
                        if (orderEventList[i]._eventData._name.Equals(_ppippiOldEventList[j]._eventData._name))
                        {
                            _ppippiOldEventList[j].transform.SetSiblingIndex(i);
                            break;
                        }
                    }
                }
                break;
        }

    }
}