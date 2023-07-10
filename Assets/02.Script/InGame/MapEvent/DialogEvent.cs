using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트를 상속받을 객체는 대화가 가능한 객체 여야한다.
// 대화 관련 처리 이벤트를 담당하는 클래스, 현재 처리할 이벤트 외에 다른 이벤트가 생기면 함수를 새로 만들면 된다.
public abstract class DialogEvent : MapEvent
{
    protected enum eDefaultLookDir { Left, Right, }

    public CampaignUI _campaignUI;
    public bool _isDialog; // 대화가 시작된 후, 대화가 끝났는지 아닌지 판단하기 위한 변수
    [SerializeField] protected SpriteRenderer _sr;
    [SerializeField] protected eDefaultLookDir _defaultLookDir;

    /// <summary>
    /// 상속받은 객체마다 다른 이벤트 처리 방식을 위해, 다양한 기능들을 객체마다 다르게 조합하여 사용한다. 
    /// </summary>
    /// <param name="eventContext"></param>
    public abstract void DoDialogEvent(string eventContext);

    // 대화 이벤트 중 Y/N 관련 처리 함수
    public virtual void SelectYesOrNo() { }

    // 대화 이벤트 중 사운드 관련 처리 함수
    public virtual void PlaySound() { }

    // 대화 이벤트 중 그 외 나머지 작업들 처리할 함수 (함수명 수정 요함)
    public virtual void EtcFunction() { }

    protected void FlipSprite(float myPosX, float targetPosX)
    {
        bool isLookLeft = _defaultLookDir == eDefaultLookDir.Left ? true : false;
        //switch (_defaultLookDir)
        //{
        //    case eDefaultLookDir.Left:
        //        // 플립x 체크 시 오른쪽을 보게 됨
        //        break;
        //    case eDefaultLookDir.Right:
        //        // 플립x 체크 시 왼쪽을 보게 됨
        //        break;
        //}
        if (myPosX - targetPosX > 0.0f)
        {
            _sr.flipX = !isLookLeft;
        }
        else if (myPosX - targetPosX < 0.0f)
        {
            _sr.flipX = isLookLeft;
        }
    }

    //public dfdfdfd
}