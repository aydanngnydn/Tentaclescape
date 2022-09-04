using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D collider;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        collider = GetComponent<Collider2D>();
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        GameObject gameObject = other.gameObject;

        if (gameObject != null)
        {
            if (gameObject.TryGetComponent(out BulletMovement _))
            {
                anim.SetTrigger("Death");
                Destroy(collider);
                Destroy (this.gameObject, anim.runtimeAnimatorController.animationClips.Length); 
            }
        }
    }
}
