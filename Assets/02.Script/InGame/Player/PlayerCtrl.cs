using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Range(4.0f, 9.0f)]
    [SerializeField]
    private float _movSpeed;

    [Range(50.0f, 60.0f)]
    [SerializeField]
    private float _jumpForce;

    [Space(9.0f)]
    [SerializeField]
    private GameObject _researchColl;

    [Space(9.0f)]
    public int _playerCollectMemoryCount;

    [SerializeField]
    private GameObject _ppiPpiObj;

    private PpiPpi _ppiPpi;
    private Rigidbody2D _rbody2D;
    private Animator _animator;
    private CircleCollider2D _researchColl2D;
    private Grounded _grounded;
    private float _h;
    private Vector3 _movDir;
    private bool _isJumpInput;

    private readonly int _hashMove = Animator.StringToHash("isMove");
    

    private void Awake()
    {
        _ppiPpi = _ppiPpiObj.GetComponent<PpiPpi>();
        _animator = GetComponent<Animator>();
        _rbody2D = GetComponent<Rigidbody2D>();
        _grounded = GetComponentInChildren<Grounded>();
        _researchColl2D = _researchColl.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            _isJumpInput = true;
        }
        else
        {
            _isJumpInput = false;
        }

        if (Input.GetKey(KeyCode.F))
        {
            InteractWithMapEvent();
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            bool isHoldPpippi = _ppiPpi._isHoldPos;
            _ppiPpi.TogglePpiPpiPos(!isHoldPpippi);
        }
    }

    private void FixedUpdate()
    {
        if (_h != 0.0f)
        {
            _animator.SetBool(_hashMove, true);
            Move();
        }
        else
        {
            _animator.SetBool(_hashMove, false);
        }

        if (_isJumpInput && _grounded._isGrounded)
        {
            Jump();
        }
    }

    public void GetMemoryFragment()
    {
        // 사운드 연출

        _playerCollectMemoryCount++;
    }

    private void Move()
    {
        _movDir = (_h * Vector2.right).normalized;
        // _rbody2D.MovePosition(_rbody2D.position + (_movDir * _movSpeed * Time.deltaTime));
        // _rbody2D.AddForce(_movDir * _movSpeed * Time.deltaTime, ForceMode2D.Impulse);
        transform.position += _movDir * _movSpeed * Time.deltaTime;
        
    }

    private void Jump()
    {
        _rbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void InteractWithMapEvent()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position, _researchColl2D.radius, 1 << LayerMask.NameToLayer("MapEvent"));
        if (coll == null)
        {
            return;
        }

        MapEvent mapEvent = coll.GetComponent<MapEvent>();
        mapEvent.Interaction(this);
    }
}
