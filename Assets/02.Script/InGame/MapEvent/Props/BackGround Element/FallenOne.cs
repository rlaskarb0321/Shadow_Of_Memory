using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenOne : DialogEvent
{
    [Space(10.0f)][SerializeField] private PpippiEventMgr _ppippiEventMgr;

    [Header("=== Fallen One ===")]
    [SerializeField] private float _movSpeed;

    private Vector2 _movDir;
    private Animator _animator;
    private Rigidbody2D _rbody2D;
    private readonly int _hashIsTalk = Animator.StringToHash("isTalk");

    private void Awake()
    {
        _rbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (ProductionMgr._isPlayProduction)
            return;

        _movDir = new Vector2(_sr.flipX ? -1.0f : 1.0f, 0.0f);
        transform.Translate(_movDir * _movSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallenOne Clamp"))
        {
            _sr.flipX = !_sr.flipX;
        }
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

        FlipSprite(transform.position.x, player.transform.position.x);
        ppippiEventData data = new ppippiEventData(ConstData._LITTLEGIRL_EVENT_NAME, ConstData._LITTLEGIRL_EVENT_IDX, "Ppippi Dialog");

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
        // 또 다른 잠식된 자와 대화를 하면 발생시킬 이벤트들
    }
}
