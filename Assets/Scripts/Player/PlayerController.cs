using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem dust;

    [Header("Horizontal Movement")]
    private Vector2 inputDirection;
    private bool facingRight = true;
    [SerializeField] private float moveSpeed;

    [Header("Ground Check")]
    private bool isPlayerGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Vector3 colliderOffset;
    [SerializeField] private LayerMask groundCheckLayer;

    [Header("Jump")]
    [SerializeField] private float jumpSpeed = 15f;
    [SerializeField] private float jumpDelay = 0.25f;
    private bool jumpMode = true;
    private float jumpTimer;

    [Header("Physics")]
    private Rigidbody2D rigidBody;
    [SerializeField] private float maxSpeed = 7f;
    [SerializeField] private float linearDrag = 2f;
    [SerializeField] private float gravity = 1;
    [SerializeField] private float fallMultiplier = 4f;


    public event Action OnPlayerJump;
    public event Action OnPlayerFly;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetPlayerInput();
        if (jumpMode)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpTimer = Time.time + jumpDelay;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            jumpMode = !jumpMode;
        }

        PlayerFlyingCheck();
    }

    private void FixedUpdate()
    {
        MovePlayer(inputDirection);

        ModifyPhsyics();

        if (CanPlayerJump())
        {
            JumpPlayer();
        }
    }

    private void GetPlayerInput()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnGroundCheck();
    }

    private void MovePlayer(Vector2 direction)
    {
        rigidBody.AddForce(direction.x * moveSpeed * Vector2.right);

        if (!jumpMode)
        {
            rigidBody.AddForce(direction.y * moveSpeed * Vector2.up);
        }

        if (CanPlayerFlip())
        {
            FlipFace();
        }

        if (Mathf.Abs(rigidBody.velocity.x) > maxSpeed)
        {
            rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
        }
    }

    private void JumpPlayer()
    {
        dust.startLifetime = 0.1f;
        CreateDust();
        OnPlayerJump?.Invoke();
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        rigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
    }

    private void FlipFace()
    {
        if (isPlayerGrounded)
        {
            dust.startLifetime = 0.5f;
            CreateDust();
        }
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    private void ModifyPhsyics()
    {
        bool changingDirection = (inputDirection.x > 0 && rigidBody.velocity.x < 0) || (inputDirection.x < 0 && rigidBody.velocity.x > 0);
        if (isPlayerGrounded)
        {
            if (Math.Abs(inputDirection.x) < 0.4f || changingDirection)
            {
                rigidBody.drag = linearDrag;
            }
            else
            {
                rigidBody.drag = linearDrag * 0.8f;
            }

            rigidBody.gravityScale = 0;
        }
        else if (jumpMode)
        {
            rigidBody.gravityScale = gravity;
            rigidBody.drag = linearDrag;

            if (rigidBody.velocity.y < 0)
            {
                rigidBody.gravityScale = gravity * fallMultiplier;
            }
            else if (rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
            {
                rigidBody.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
        else
        {
            rigidBody.drag = linearDrag;
            rigidBody.gravityScale = 0;
        }
    }

    #region Particle Dust

    void CreateDust()
    {
        dust.Play();
    }
    
    #endregion

    #region CanPlayer IsPlayer

    private bool CanPlayerFlip()
    {
        if ((inputDirection.x < 0) && facingRight || (inputDirection.x > 0) && !facingRight)
        {
            return true;
        }
        return false;
    }

    private bool CanPlayerJump()
    {
        return isPlayerGrounded && jumpTimer > Time.time;
    }

    private void OnGroundCheck()
    {
        isPlayerGrounded = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundCheckDistance, groundCheckLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundCheckDistance, groundCheckLayer);
    }

    public bool IsPlayerOnGround()
    {
        return isPlayerGrounded;
    }

    private void PlayerFlyingCheck()
    {
        if (!jumpMode && !isPlayerGrounded)
        {
            OnPlayerFly?.Invoke();
        }
    }

    #endregion

    #region Gizmos

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + (Vector3.down * groundCheckDistance));
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + (Vector3.down * groundCheckDistance));
    }
    #endregion
}