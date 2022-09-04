using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D collider;

    private Score score;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        collider = GetComponent<Collider2D>();
        score = FindObjectOfType<Score>();

    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        GameObject gameObject = other.gameObject;

        if (gameObject != null)
        {
            if (gameObject.TryGetComponent(out BulletMovement _))
            {
                score.KillScoreUpdate();
                anim.SetTrigger("Death");
                Destroy(collider);
                Destroy (this.gameObject, anim.runtimeAnimatorController.animationClips.Length); 
            }
        }
    }
}
