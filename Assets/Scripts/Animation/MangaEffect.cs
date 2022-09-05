using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangaEffect : MonoBehaviour
{
    private PlayerHealth health;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponentInParent<PlayerHealth>();
    }

    private void OnEnable()
    {
        health.OnHealthDecrease += MangaEffectAnimStart;
    }

    private void OnDisable()
    {
        health.OnHealthDecrease -= MangaEffectAnimStart;
    }

    private void MangaEffectAnimStart()
    {
        animator.SetTrigger("TakeDamage");
    }
}
