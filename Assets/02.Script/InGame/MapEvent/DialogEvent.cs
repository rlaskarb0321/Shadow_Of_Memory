using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트를 상속받을 객체는 대화가 가능한 객체 여야한다.
// 대화 관련 처리 이벤트를 담당하는 클래스, 현재 처리할 이벤트 외에 다른 이벤트가 생기면 함수를 새로 만들면 된다.
public abstract class DialogEvent : MapEvent
{
    public CampaignUI _campaignUI;

    // 상속받은 객체마다 다른 이벤트 처리 방식을 위해, 아래에 있는 메서드들을 객체마다 다양하게 조합하여 사용한다.
    public abstract void DoDialogEvent(string eventContext);

    // 대화 이벤트 중 Y/N 관련 처리 함수
    public virtual void SelectYesOrNo() { }

    // 대화 이벤트 중 사운드 관련 처리 함수
    public virtual void PlaySound() { }

    // 대화 이벤트 중 그 외 나머지 작업들 처리할 함수 (함수명 수정 요함)
    public virtual void EtcFunction() { }
}
