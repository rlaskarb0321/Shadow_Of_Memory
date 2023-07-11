using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    // SerializeField
    [Range(2.5f, 15.0f)] [SerializeField] private float _movSpeed; // 움직이는 속도값
    [Range(30.0f, 60.0f)] [SerializeField] private float _jumpForce; // 점프력
    [SerializeField] private GameObject _footPos;
    [Space(9.0f)] [SerializeField] private GameObject _researchColl; // 주위에 MapEvent 찾는 관련 콜리더
    [SerializeField] private Transform _groundCollObj; // 땋에 닿음판정 관련 콜리더 판정하는 게임오브젝트
    [SerializeField] private GameVFXPool _groundedVFXPool;

    [Header("=== Sound ===")]
    [SerializeField] private AudioClip _jumpSound;

    // HideInInspector
    private Rigidbody2D _rbody2D;
    private Animator _animator;
    private CircleCollider2D _researchColl2D;
    private Grounded _grounded;
    private float _h;
    [SerializeField] private Vector3 _movDir;
    private AudioSource _audio;
    private bool _isJumpInput;

    private readonly int _hashMove = Animator.StringToHash("isMove");
    private readonly int _hashFall = Animator.StringToHash("isFall");
    private readonly int _hashisGrounded = Animator.StringToHash("isGrounded");
    private readonly int _hashisJumpInput = Animator.StringToHash("isJumpInput");
    

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _rbody2D = GetComponent<Rigidbody2D>();
        _grounded = GetComponentInChildren<Grounded>();
        _researchColl2D = _researchColl.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        ManagePlayerInput();
        _animator.SetBool(_hashisGrounded, _grounded._isGrounded);
        _animator.SetBool(_hashFall, _rbody2D.velocity.y < -0.05f);

        if (ProductionMgr._isPlayProduction)
        {
            // 영상 재생중엔 점프와 움직이기 불가능
            _h = 0.0f;
            _isJumpInput = false;
            return;
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

        if (_isJumpInput && _grounded._isGrounded && !_animator.GetBool(_hashisJumpInput))
        {
            _animator.SetBool(_hashisJumpInput, true);
            Jump();
        }
    }


    // jump landing 애니메이션 델리게이트
    public void EscapeJumpState()
    {
        _animator.SetBool(_hashisJumpInput, false);
        _groundedVFXPool.DisplayVFX(_footPos.transform.position);
    }

    private void ManagePlayerInput()
    {
        _h = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKey(KeyCode.Space))
            _isJumpInput = true;
        else
            _isJumpInput = false;

        if (Input.GetKey(KeyCode.F))
        {
            InteractWithMapEvent();
        }
    }

    private void Move()
    {
        float scaleX = _h;
        RaycastHit2D groundHit = Physics2D.Raycast(_footPos.transform.position, Vector2.down, 1.5f, 1 << LayerMask.NameToLayer("Ground"));

        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        _movDir = (_h * Vector2.right).normalized;
        if (groundHit.collider != null)
        {
            if (Vector2.Angle(transform.up, groundHit.normal) != 0.0f)
            {
                float angle;
                Vector3 slopeDir;
                Vector3 movDir;
                
                slopeDir = Vector3.ProjectOnPlane(new Vector2(_movDir.x, _movDir.y), groundHit.normal);
                angle = Vector2.SignedAngle(_movDir, slopeDir);
                movDir = Quaternion.Euler(0.0f, 0.0f, angle) * _movDir;

                _movDir = movDir.normalized;
            }
        }

        transform.position += _movDir * _movSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        if (_jumpSound != null)
        {
            print("l");
            _audio.PlayOneShot(_jumpSound);
        }
        _rbody2D.velocity = Vector2.zero;
        _rbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void InteractWithMapEvent()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position, _researchColl2D.radius, 1 << LayerMask.NameToLayer("MapEvent"));
        if (coll == null)
        {
            // 이곳에 상호작용가능한 물체가 없음을 표시
            return;
        }

        MapEvent mapEvent = coll.GetComponent<MapEvent>();
        mapEvent.Interaction(this);
    }
}
