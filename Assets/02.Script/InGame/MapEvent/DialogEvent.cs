using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ�� ��ӹ��� ��ü�� ��ȭ�� ������ ��ü �����Ѵ�.
// ��ȭ ���� ó�� �̺�Ʈ�� ����ϴ� Ŭ����, ���� ó���� �̺�Ʈ �ܿ� �ٸ� �̺�Ʈ�� ����� �Լ��� ���� ����� �ȴ�.
public abstract class DialogEvent : MapEvent
{
    protected enum eDefaultLookDir { Left, Right, }

    public CampaignUI _campaignUI;
    public bool _isDialog; // ��ȭ�� ���۵� ��, ��ȭ�� �������� �ƴ��� �Ǵ��ϱ� ���� ����
    [SerializeField] protected SpriteRenderer _sr;
    [SerializeField] protected eDefaultLookDir _defaultLookDir;

    /// <summary>
    /// ��ӹ��� ��ü���� �ٸ� �̺�Ʈ ó�� ����� ����, �پ��� ��ɵ��� ��ü���� �ٸ��� �����Ͽ� ����Ѵ�. 
    /// </summary>
    /// <param name="eventContext"></param>
    public abstract void DoDialogEvent(string eventContext);

    // ��ȭ �̺�Ʈ �� Y/N ���� ó�� �Լ�
    public virtual void SelectYesOrNo() { }

    // ��ȭ �̺�Ʈ �� ���� ���� ó�� �Լ�
    public virtual void PlaySound() { }

    // ��ȭ �̺�Ʈ �� �� �� ������ �۾��� ó���� �Լ� (�Լ��� ���� ����)
    public virtual void EtcFunction() { }

    protected void FlipSprite(float myPosX, float targetPosX)
    {
        bool isLookLeft = _defaultLookDir == eDefaultLookDir.Left ? true : false;
        //switch (_defaultLookDir)
        //{
        //    case eDefaultLookDir.Left:
        //        // �ø�x üũ �� �������� ���� ��
        //        break;
        //    case eDefaultLookDir.Right:
        //        // �ø�x üũ �� ������ ���� ��
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