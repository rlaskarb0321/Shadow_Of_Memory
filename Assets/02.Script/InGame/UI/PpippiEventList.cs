using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ���� newList, oldList �� ó���� �ؾ��Ѵ�.
public class PpippiEventList : MonoBehaviour
{
    private enum eOrderBy { Index, Name, }
    private PpippiEvent _newEvent;

    public void CreateNewList(PpippiEvent ppippiEvent)
    {
        _newEvent = ppippiEvent;
        
        // ���� Event �׸� ���� �̹� �ִٸ�, �ش� ���� oldEvent �׸����� �ű��. �ű�鼭, ���� ���ذ��� �����Ͽ� �� ������ �����Ѵ�.
    }

    public void OrderByDropDownValue()
    {

    }
}
