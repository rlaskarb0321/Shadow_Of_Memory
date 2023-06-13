using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private GameObject _stageMgrObj;

    [SerializeField]
    private Transform _playerBody;

    [Space(9.0f)]
    public int _playerCollectMemoryCount;

    [SerializeField]
    private Transform _groundCollObj;

    //[SerializeField]
    //private GameObject _ppiPpiObj;

    //private PpiPpi _ppiPpi;
    private StageMgr _stageMgr;
    private AnimatorChange _animChange;
    private Rigidbody2D _rbody2D;
    private Animator _animator;
    private CircleCollider2D _researchColl2D;
    private Grounded _grounded;
    private float _h;
    private Vector3 _movDir;
    private bool _isJumpInput;
    private BoxCollider2D _boxColl;
    private CircleCollider2D _circleColl;

    private readonly int _hashMove = Animator.StringToHash("isMove");
    private readonly int _hashFall = Animator.StringToHash("isFall");
    private readonly int _hashisGrounded = Animator.StringToHash("isGrounded");
    private readonly int _hashisJumpInput = Animator.StringToHash("isJumpInput");
    

    private void Awake()
    {
        //_ppiPpi = _ppiPpiObj.GetComponent<PpiPpi>();
        _animChange = _stageMgrObj.GetComponent<AnimatorChange>();
        _animator = GetComponent<Animator>();
        _rbody2D = GetComponent<Rigidbody2D>();
        _grounded = GetComponentInChildren<Grounded>();
        _researchColl2D = _researchColl.GetComponent<CircleCollider2D>();
        _stageMgr = _stageMgrObj.GetComponent<StageMgr>();
        _boxColl = GetComponent<BoxCollider2D>();
        _circleColl = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        ManagePlayerInput();

        _animator.SetBool(_hashisGrounded, _grounded._isGrounded);
        _animator.SetBool(_hashFall, _rbody2D.velocity.y < -0.05f);
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
            _animator.SetBool(_hashisJumpInput, true);
            Jump();
        }
    }

    // jumplanding 애니메이션 델리게이트
    public void EscapeJumpState()
    {
        _animator.SetBool(_hashisJumpInput, false);
    }

    public void GetMemoryFragment()
    {
        // 사운드 연출

        _playerCollectMemoryCount++;
    }

    public void SwitchPlayerCharacter(int currLevel)
    {
        int nextLevel = currLevel + 1;

        _animChange.ChangeAnimator(nextLevel);
        switch (currLevel)
        {
            case 0:
                Vector2 size_level_2 = new Vector2(0.84f, 1.37f);
                Vector2 boxOffset_level_2 = Vector2.zero;
                Vector2 circleOffset_level_2 = new Vector2(0.0f, -0.62f);
                float radius_level_2 = 0.41f;

                _boxColl.size = size_level_2;
                _boxColl.offset = boxOffset_level_2;
                _circleColl.offset = circleOffset_level_2;
                _circleColl.radius = radius_level_2;
                _groundCollObj.localPosition = new Vector2(0.0f, -1.008f);
                break;

            case 1:
                Vector2 size_level_3 = new Vector2(0.84f, 2.12f);
                Vector2 boxOffset_level_3 = Vector2.zero;
                Vector2 circleOffset_level_3 = new Vector2(0.0f, -0.86f);
                float radius_level_3 = 0.41f;

                _boxColl.size = size_level_3;
                _boxColl.offset = boxOffset_level_3;
                _circleColl.offset = circleOffset_level_3;
                _circleColl.radius = radius_level_3;
                _groundCollObj.localPosition = new Vector2(0.0f, -1.289f);
                break;

            default:
                break;
        }
    }

    private void ManagePlayerInput()
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
    }

    private void Move()
    {
        float scaleX = _h;
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        _movDir = (_h * Vector2.right).normalized;
        // _rbody2D.MovePosition(_rbody2D.position + (_movDir * _movSpeed * Time.deltaTime));
        // _rbody2D.AddForce(_movDir * _movSpeed * Time.deltaTime, ForceMode2D.Impulse);
        // _rbody2D.MovePosition(_rbody2D.position + _movDir * _movSpeed * Time.deltaTime);
        
        transform.position += _movDir * _movSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        _rbody2D.velocity = Vector2.zero;
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
