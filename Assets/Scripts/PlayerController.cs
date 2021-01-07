using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;
    public float jumpForce = 2.5f;
    public float longIdleTime = 5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    // Reference
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    // Movement
    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _isGrounded;

    // Attack
    private bool _isAttacking;

    // Long Idle
    private float _longIdleTimer;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        // Used for games with Joystick Control, not with keys
        //float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (_isAttacking == false)
        {
            // Take less time to capture keys on the Game
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _movement = new Vector2(horizontalInput, 0f);

            // Flip Character
            if (horizontalInput < 0f && _facingRight == true)
            {
                Flip();
            }
            else if (horizontalInput > 0f && _facingRight == false)
            {
                Flip();
            }
        }

        // Is grounded?
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Is Jumping?
        if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Wanna Attack?
        if (Input.GetButtonDown("Fire1") && _isGrounded == true && _isAttacking == false)
        {
            _movement = Vector2.zero;
            _rigidbody2D.velocity = Vector2.zero;
            _animator.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {
        if (_isAttacking == false)
        {
            float horizontalVelocity = _movement.normalized.x * speed;
            _rigidbody2D.velocity = new Vector2(horizontalVelocity, _rigidbody2D.velocity.y);
        }
    }

    void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody2D.velocity.y);

        // Animator
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        } else {
            _isAttacking = false;
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            _longIdleTimer += Time.deltaTime;

            if (_longIdleTimer >= longIdleTime)
            {
                _animator.SetTrigger("LongIdle");
            }
        } else {
            _longIdleTimer = 0f;
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
