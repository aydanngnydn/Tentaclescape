using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;

    private PlayerController controller;
    private PlayerHealth health;

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
    }

    private void OnDisable()
    {
        health.OnHealthDecrease -= HitAnim;
        health.OnPlayerDeath -= DeathAnim;
        controller.OnPlayerJump += JumpAnim;
    }

    private void Update()
    {
        if (!health.AliveCheck())
        {
            IdleAnim();
        }
        else
        {
            RunAnim();
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

    private void IdleAnim()
    {
        animator.SetFloat("PlayerSpeed", 0);
    }

    private void RunAnim()
    {
        animator.SetFloat("PlayerSpeed", Mathf.Abs(rigidBody.velocity.x));
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