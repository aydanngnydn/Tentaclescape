using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed = 15f;
    [SerializeField] private float jumpDelay = 0.25f;
    private float jumpTimer;
    private Vector2 inputDirection;
    private bool facingRight = true;

    [Header("Ground Check")]
    [SerializeField] private bool isPlayerGrounded;
    [SerializeField] private LayerMask groundCheckLayer;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Vector3 colliderOffset;

    [Header("Physics")]
    [SerializeField] private float maxSpeed = 7f;
    [SerializeField] private float linearDrag = 4f;
    [SerializeField] private float gravity = 1;
    [SerializeField] private float fallMultiplier = 4f;

    #region Components
    private Rigidbody2D rigidBody;
    private Animator animator;
    #endregion

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetPlayerInput();

        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(inputDirection.x);
        ModifyPhysics();

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

    private void MovePlayer(float horizontal)
    {
        rigidBody.AddForce(horizontal * moveSpeed * Vector2.right);

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
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        rigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
    }

    private void FlipFace()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    private void ModifyPhysics()
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
                rigidBody.drag = 0f;
            }
            rigidBody.gravityScale = 0;
        }
        else
        {
            rigidBody.drag = linearDrag * 0.15f;

            if (rigidBody.velocity.y < 0)
            {
                rigidBody.gravityScale = gravity * fallMultiplier;
            }
            else if (rigidBody.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rigidBody.gravityScale = gravity * (fallMultiplier / 2);
            }
            else
            {
                rigidBody.gravityScale = gravity;
            }
        }
    }

    #region CanPlayer

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
        //isPlayerGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        isPlayerGrounded = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundCheckDistance, groundCheckLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundCheckDistance, groundCheckLayer);
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