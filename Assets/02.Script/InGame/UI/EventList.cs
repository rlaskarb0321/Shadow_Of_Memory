using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventList : MonoBehaviour
{
    [Header("=== UI ===")]
    [SerializeField] private Text _index;
    [SerializeField] private Text _name;
    [SerializeField] private Text _watched;

    public bool IsWatched
    {
        set
        {
            if (value)
            {
                _watched.text = "��û��";
            }
            else
            {
                _watched.text = "��û���� ����";
            }
        } 
    }
    private bool _isWatched;

    // �̺�Ʈ ����Ʈ�� UI���� �ʱ�ȭ ��Ű�� ���� ȣ�� �����ڿ� ����� �޼���
    public void InitEventListValue(string eventName, int eventIndex)
    {
        _index.text = eventIndex.ToString();
        _name.text = eventName;
        IsWatched = false;
    }

    // �̺�Ʈ ����Ʈ�� Ŭ�� ���� �� ������ �Լ�
    // ���� �ű� �̺�Ʈ ����Ʈ�� ������ Ŭ���Ǿ��ٸ� -> ������ �Ʒ��� ����, �����鼭 ���Ĺ�Ŀ����� �°� �����������
    public void OnClickEventList()
    {
        IsWatched = true;
    }
}
