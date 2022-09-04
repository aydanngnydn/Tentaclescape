using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    protected void OnCollisionEnter2D(Collision2D other)
    {
        GameObject gameObject = other.gameObject;

        if (gameObject != null)
        {
            if (gameObject.TryGetComponent(out BulletMovement _))
            {
                anim.SetTrigger("Death");
                Destroy (this.gameObject, 0.5f); 
            }
        }
    }
}
