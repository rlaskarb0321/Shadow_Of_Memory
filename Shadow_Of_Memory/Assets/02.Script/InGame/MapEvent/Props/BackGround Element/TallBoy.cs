using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallBoy : FallenOne
{
    public override void Interaction(PlayerCtrl player)
    {
        if (_campaignUI._isDialogOn)
            return;

        FlipSprite(transform.position.x, player.transform.position.x);
        ppippiEventData data = new ppippiEventData(ConstData._TALLBOY_EVENT_NAME, ConstData._TALLBOY_EVENT_IDX, "Ppippi Dialog");

        _animator.SetBool(_hashIsTalk, true);
        _campaignUI.SetDialogOn(true, "Ppippi Dialog", this);

        if (!_isFirstMeet)
        {
            _ppippiEventMgr.CreateNewList(data);
            _isFirstMeet = true;
        }
    }

    public override void DoDialogEvent(string eventContext)
    {

    }
}
