using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트에서 newList, oldList 값 처리를 해야한다.
public class PpippiEventList : MonoBehaviour
{
    private enum eOrderBy { Index, Name, }
    private PpippiEvent _newEvent;

    public void CreateNewList(PpippiEvent ppippiEvent)
    {
        _newEvent = ppippiEvent;
        
        // 강조 Event 항목에 값이 이미 있다면, 해당 값을 oldEvent 항목으로 옮긴다. 옮기면서, 정렬 기준값을 참조하여 재 정렬후 나열한다.
    }

    public void OrderByDropDownValue()
    {

    }
}
