using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;

    [SerializeField] private BulletMovement bullet;
    private PlayerHealth health;
    [SerializeField] private float speedOffset;

    private void Awake()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        health = GetComponentInParent<PlayerHealth>();
    }

    private void OnEnable()
    {
        health.OnPlayerDeath += DeathAnim;
        bullet.OnBulletStopStart += StopTimeAnimStart;
        bullet.OnBulletStopEnd += StopTimeAnimEnd;
    }

    private void OnDisable()
    {
        health.OnPlayerDeath -= DeathAnim;
        bullet.OnBulletStopStart -= StopTimeAnimStart;
        bullet.OnBulletStopEnd -= StopTimeAnimEnd;
    }

    private void Update()
    {
            IdleRunAnims();
    }

    //private void HitAnim()
    //{
    //    animator.SetTrigger("TakeDamage");
    //}

    private void DeathAnim()
    {
        animator.SetTrigger("Death");
    }

    private void IdleRunAnims()
    {
        if (Mathf.Abs(rigidBody.velocity.x) > speedOffset)
        {
            animator.SetFloat("PlayerSpeed", rigidBody.velocity.x);
        }
        else
        {
            animator.SetFloat("PlayerSpeed", 0);
        }
    }
    private void StopTimeAnimStart()
    {
        animator.SetBool("IsStopTime", true);
    }  
    
    private void StopTimeAnimEnd()
    {
        animator.SetBool("IsStopTime", false);
    }
}