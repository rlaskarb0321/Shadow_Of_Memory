using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpippiDialogBtn : UIInteractBase
{
    // 포인터가 들어왔을때
    public override void OnPointerEnter()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    // 포인터가 나갔을 때
    public override void OnPointerExit()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
