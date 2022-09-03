using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;

    private PlayerController controller;
    private PlayerHealth health;
    [SerializeField] private float speedOffset;

    private void Awake()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        controller = GetComponentInParent<PlayerController>();
        health = GetComponentInParent<PlayerHealth>();
    }

    private void OnEnable()
    {
        health.OnHealthDecrease += HitAnim;
        health.OnPlayerDeath += DeathAnim;
        controller.OnPlayerJump += JumpAnim;
        controller.OnPlayerFly += FlyAnim;
    }

    private void OnDisable()
    {
        health.OnHealthDecrease -= HitAnim;
        health.OnPlayerDeath -= DeathAnim;
        controller.OnPlayerJump += JumpAnim;
        controller.OnPlayerFly -= FlyAnim;
    }

    private void Update()
    {
        if (controller.IsPlayerOnGround())
        {
            IdleRunAnims();
        }
    }

    private void HitAnim()
    {
        animator.SetTrigger("TakeDamage");
    }

    private void DeathAnim()
    {
        animator.SetTrigger("Death");
    }

    private void IdleRunAnims()
    {
        animator.SetBool("IsFlying", false);

        if (Mathf.Abs(rigidBody.velocity.x) > speedOffset)
        {
            animator.SetFloat("PlayerSpeed", Mathf.Abs(rigidBody.velocity.x));
        }
        else
        {
            animator.SetFloat("PlayerSpeed", 0);
        }
    }

    private void JumpAnim()
    {
        animator.SetTrigger("Jump");
    }

    private void FlyAnim()
    {
        animator.SetBool("IsFlying", true);
    }
}