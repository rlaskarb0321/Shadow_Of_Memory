using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGirlFallenOne : DialogEvent
{
    [Space(10.0f)][SerializeField] private PpippiEventMgr _ppippiEventMgr;

    [Header("=== Fallen One ===")]
    [SerializeField] private float _movSpeed;

    private Animator _animator;
    private Rigidbody2D _rbody2D;
    private readonly int _hashIsTalk = Animator.StringToHash("isTalk");

    private void Awake()
    {
        _rbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (_isDialog)
        {
            _interactAlarm.SetActive(false);
            return;
        }

        base.OnTriggerStay2D(collision);
    }

    public override void Interaction(PlayerCtrl player)
    {
        if (_campaignUI._isDialogOn)
            return;

        //Vector3 originScale = transform.localScale;
        //if (transform.position.x - player.transform.position.x > 0.0f)
        //{
        //    Vector3 changeScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //    originScale = changeScale;
        //}
        //transform.localScale = originScale;

            _animator.SetBool(_hashIsTalk, true);
        ppippiEventData data = 
            new ppippiEventData(ConstData._LITTLEGIRL_EVENT_NAME, ConstData._LITTLEGIRL_EVENT_IDX, "Ppippi Dialog");
        _campaignUI.SetDialogOn(true, "Ppippi Dialog", this);
        _ppippiEventMgr.CreateNewList(data);
    }

    public override void DoDialogEvent(string eventContext)
    {
        // 또 다른 잠식된 자와 대화를 하면 발생시킬 이벤트들
    }
}
