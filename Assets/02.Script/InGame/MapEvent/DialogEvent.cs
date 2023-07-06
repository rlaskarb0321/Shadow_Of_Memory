using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ�� ��ӹ��� ��ü�� ��ȭ�� ������ ��ü �����Ѵ�.
// ��ȭ ���� ó�� �̺�Ʈ�� ����ϴ� Ŭ����, ���� ó���� �̺�Ʈ �ܿ� �ٸ� �̺�Ʈ�� ����� �Լ��� ���� ����� �ȴ�.
public abstract class DialogEvent : MapEvent
{
    public CampaignUI _campaignUI;

    // ��ӹ��� ��ü���� �ٸ� �̺�Ʈ ó�� ����� ����, �Ʒ��� �ִ� �޼������ ��ü���� �پ��ϰ� �����Ͽ� ����Ѵ�.
    public abstract void DoDialogEvent(string eventContext);

    // ��ȭ �̺�Ʈ �� Y/N ���� ó�� �Լ�
    public virtual void SelectYesOrNo() { }

    // ��ȭ �̺�Ʈ �� ���� ���� ó�� �Լ�
    public virtual void PlaySound() { }

    // ��ȭ �̺�Ʈ �� �� �� ������ �۾��� ó���� �Լ� (�Լ��� ���� ����)
    public virtual void EtcFunction() { }
}
