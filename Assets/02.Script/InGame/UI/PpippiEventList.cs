using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트에서 newList, oldList 값 처리를 해야한다.
public class PpippiEventList : MonoBehaviour
{
    [SerializeField] private GameObject _newEventItem;
    [SerializeField] private GameObject _oldEventItem;
    [SerializeField] private GameObject _eventListPrefabs;

    private enum eOrderBy { Index, Name, }

    public void CreateNewList(PpippiEventData data)
    {
        // 강조 Event 항목에 값이 이미 있다면, 이미 있던 값을 oldEvent 항목으로 옮기고, 새로 들어온 값이 강조 Event로 들어간다.
        // 옮기면서, 정렬 기준값을 참조하여 재 정렬후 나열한다.
        if (_newEventItem.transform.childCount != 0)
        {
            Transform currNewEvent = _newEventItem.transform.GetChild(0);
            PpippiEvent eventList = 
                Instantiate(_eventListPrefabs, Vector3.zero, Quaternion.identity, _newEventItem.transform).GetComponent<PpippiEvent>();

            currNewEvent.SetParent(_oldEventItem.transform);
            eventList.SetEventValue(data);
        }
    }

    public void OrderByDropDownValue()
    {

    }
}
