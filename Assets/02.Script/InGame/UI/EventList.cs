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
                _watched.text = "시청함";
            }
            else
            {
                _watched.text = "시청하지 않음";
            }
        } 
    }
    private bool _isWatched;

    // 이벤트 리스트의 UI값을 초기화 시키기 위한 호출 생성자와 비슷한 메서드
    public void InitEventListValue(string eventName, int eventIndex)
    {
        _index.text = eventIndex.ToString();
        _name.text = eventName;
        IsWatched = false;
    }

    // 이벤트 리스트를 클릭 했을 때 실행할 함수
    // 만일 신규 이벤트 리스트에 있을때 클릭되었다면 -> 위에서 아래로 내림, 내리면서 정렬방식에따라 맞게 정렬해줘야함
    public void OnClickEventList()
    {
        IsWatched = true;
    }
}
