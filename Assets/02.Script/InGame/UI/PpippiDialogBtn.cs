using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpippiDialogBtn : UIInteractBase
{
    // �����Ͱ� ��������
    public override void OnPointerEnter()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    // �����Ͱ� ������ ��
    public override void OnPointerExit()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
