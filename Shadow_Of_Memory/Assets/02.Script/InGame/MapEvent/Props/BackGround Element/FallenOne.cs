using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FallenOne : DialogEvent
{
    [Header("=== Fallen One ===")]
    [SerializeField] protected PpippiEventMgr _ppippiEventMgr;
    [SerializeField] protected float _movSpeed;

    protected Vector2 _movDir;
    protected Animator _animator;
    protected Rigidbody2D _rbody2D;
    protected readonly int _hashIsTalk = Animator.StringToHash("isTalk");

    protected void Awake()
    {
        _rbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        if (ProductionMgr._isPlayProduction)
            return;

        if (!_isDialog && _animator.GetBool(_hashIsTalk).Equals(true))
        {
            _animator.SetBool(_hashIsTalk, false);
        }

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
}
