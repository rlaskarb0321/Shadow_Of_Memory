using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ�� ��ӹ��� ��ü�� ��ȭ�� ������ ��ü �����Ѵ�.
// ��ȭ ���� ó�� �̺�Ʈ�� ����ϴ� Ŭ����, ���� ó���� �̺�Ʈ �ܿ� �ٸ� �̺�Ʈ�� ����� �Լ��� ���� ����� �ȴ�.
public abstract class DialogEvent : MapEvent
{
    public CampaignUI _campaignUI;
    public bool _isDialog; // ��ȭ�� ���۵� ��, ��ȭ�� �������� �ƴ��� �Ǵ��ϱ� ���� ����

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

    //public dfdfdfd
}