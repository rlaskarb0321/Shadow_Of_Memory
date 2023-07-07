using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// 이 스크립트에서 newList, oldList 값 처리를 해야한다.
public class PpippiEventList : MonoBehaviour
{
    [Header("=== Event Item ===")]
    [SerializeField] private GameObject _newEventItem;
    [SerializeField] private GameObject _oldEventItem;

    [Header("=== DropDown ===")]
    public Dropdown _orderDropDown;

    [Space(10.0f)] [SerializeField] private GameObject _eventListPrefabs;

    private enum eOrderBy { Index, Name, }

    public void CreateNewList(PpippiEventData data)
    {
        PpippiEvent eventList = Instantiate(_eventListPrefabs, Vector3.zero, Quaternion.identity).GetComponent<PpippiEvent>();

        // 강조 Event 항목에 값이 이미 있다면, 이미 있던 값을 oldEvent 항목으로 옮기고, 새로 들어온 값이 강조 Event로 들어간다.
        if (_newEventItem.transform.childCount != 0)
        {
            PpippiEvent currNewEvent = _newEventItem.transform.GetChild(0).GetComponent<PpippiEvent>();

            currNewEvent.SetParentObj(_oldEventItem.transform, PpippiEvent.eMyParentObj.Old);
            eventList.SetEventValue(data, this);
            eventList.SetParentObj(_newEventItem.transform, PpippiEvent.eMyParentObj.New);
        }
        // 강조 Event 항목에 값이 없다면, 새로 들어온 값이 강조 Event로 들어간다.
        else
        {
            eventList.SetEventValue(data, this);
            eventList.SetParentObj(_newEventItem.transform, PpippiEvent.eMyParentObj.New);
        }

        // 옮기면서, 정렬 기준값을 참조하여 재 정렬후 나열한다.
        OrderByDropDownValue();
    }

    public void OrderByDropDownValue()
    {

    }

    public void OnClickEventList()
    { 

    }
}