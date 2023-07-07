using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ���� newList, oldList �� ó���� �ؾ��Ѵ�.
public class PpippiEventList : MonoBehaviour
{
    [SerializeField] private GameObject _newEventItem;
    [SerializeField] private GameObject _oldEventItem;
    [SerializeField] private GameObject _eventListPrefabs;

    private enum eOrderBy { Index, Name, }

    public void CreateNewList(PpippiEventData data)
    {
        // ���� Event �׸� ���� �̹� �ִٸ�, �̹� �ִ� ���� oldEvent �׸����� �ű��, ���� ���� ���� ���� Event�� ����.
        // �ű�鼭, ���� ���ذ��� �����Ͽ� �� ������ �����Ѵ�.
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
