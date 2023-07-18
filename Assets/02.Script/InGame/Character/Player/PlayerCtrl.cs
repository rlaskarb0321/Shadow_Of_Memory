using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    // SerializeField
    [Range(2.5f, 15.0f)] [SerializeField] private float _movSpeed; // �����̴� �ӵ���
    /*[Range(40.0f, 60.0f)]*/ [SerializeField] private float _jumpForce; // ������
    [SerializeField] private GameObject _footPos;
    [Space(9.0f)] [SerializeField] private GameObject _researchColl; // ������ MapEvent ã�� ���� �ݸ���
    [SerializeField] private Transform _groundCollObj; // ���� �������� ���� �ݸ��� �����ϴ� ���ӿ�����Ʈ
    [SerializeField] private GameVFXPool _groundedVFXPool;
    [Tooltip("���� ���� ���� �� �ش� �ӵ� �̸��̸� fall ��� ���")][SerializeField] private float _fallEntrySpeed;

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
        _animator.SetBool(_hashFall, _rbody2D.velocity.y < _fallEntrySpeed);

        if (ProductionMgr._isPlayProduction)
        {
            // ���� ����߿� ������ �����̱� �Ұ���
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


    // jump landing �ִϸ��̼� ��������Ʈ
    public void EscapeJumpState()
    {
        _animator.SetBool(_hashisJumpInput, false);
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

        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        _movDir = (_h * Vector2.right).normalized;

        StickToGround();
        transform.position += _movDir * _movSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        if (_jumpSound != null)
        {
            _audio.PlayOneShot(_jumpSound);
        }

        _groundedVFXPool.DisplayVFX(_footPos.transform.position);
        _rbody2D.velocity = Vector2.zero;
        _rbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void InteractWithMapEvent()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position, _researchColl2D.radius, 1 << LayerMask.NameToLayer("MapEvent"));
        if (coll == null)
        {
            // �̰��� ��ȣ�ۿ밡���� ��ü�� ������ ǥ��
            return;
        }

        MapEvent mapEvent = coll.GetComponent<MapEvent>();
        mapEvent.Interaction(this);
    }

    // �÷��̾��� �����̴� ������ ���� ������ ��ġ��Ŵ
    private void StickToGround()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(_footPos.transform.position, Vector2.down, 1.5f, 1 << LayerMask.NameToLayer("Ground"));

        if (groundHit.collider != null)
        {
            if (Vector2.Angle(transform.up, groundHit.normal) != 0.0f)
            {
                float angle;
                Vector3 slopeDir;
                Vector3 movDir;

                slopeDir = Vector3.ProjectOnPlane(new Vector2(_movDir.x, _movDir.y), groundHit.normal);
                angle = Vector2.SignedAngle(_movDir, slopeDir); // �� ���� �������� �ٸ� ������ ���̰��� + - �� ��Ÿ��
                movDir = Quaternion.Euler(0.0f, 0.0f, angle) * _movDir;

                _movDir = movDir.normalized;
            }
        }
    }
}
