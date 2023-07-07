using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// �� ��ũ��Ʈ���� newList, oldList �� ó���� �ؾ��Ѵ�.
public class PpippiEventMgr : MonoBehaviour
{
    [Header("=== Event Item ===")]
    [SerializeField] private GameObject _newEventItem;
    [SerializeField] private GameObject _oldEventItem;
    public Dropdown _orderDropDown;
    [Space(5.0f)] [SerializeField] private CampaignUI _campaignUI;

    [Header("=== Ppippi Alarm ===")]
    public GameObject _ppippiAlarm;

    [Space(10.0f)] [SerializeField] private GameObject _eventListPrefabs;
    private enum eOrderBy { Index, Name, }

    public void CreateNewList(PpippiEventData data)
    {
        if (!_ppippiAlarm.activeSelf)
        {
            _ppippiAlarm.SetActive(true);
        }

        PpippiEvent eventList = Instantiate(_eventListPrefabs, Vector3.zero, Quaternion.identity).GetComponent<PpippiEvent>();

        // ���� Event �׸� ���� �̹� �ִٸ�, �̹� �ִ� ���� oldEvent �׸����� �ű��, ���� ���� ���� ���� Event�� ����.
        if (_newEventItem.transform.childCount != 0)
        {
            PpippiEvent currNewEvent = _newEventItem.transform.GetChild(0).GetComponent<PpippiEvent>();

            currNewEvent.SetParentObj(_oldEventItem.transform, PpippiEvent.eMyParentObj.Old, _campaignUI, this);
            eventList.SetEventValue(data);
            eventList.SetParentObj(_newEventItem.transform, PpippiEvent.eMyParentObj.New, _campaignUI, this);
        }
        // ���� Event �׸� ���� ���ٸ�, ���� ���� ���� ���� Event�� ����.
        else
        {
            eventList.SetEventValue(data);
            eventList.SetParentObj(_newEventItem.transform, PpippiEvent.eMyParentObj.New, _campaignUI, this);
        }

        // �ű�鼭, ���� ���ذ��� �����Ͽ� �� ������ �����Ѵ�.
        OrderByDropDownValue();
    }

    public void OrderByDropDownValue()
    {

    }

    public void OnClickEventList()
    { 

    }
}