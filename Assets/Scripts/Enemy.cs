using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject destroyEffect;
    [SerializeField] protected float destroyTime;
    protected void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 contactPoint = other.GetContact(0).point;

        GameObject gameObject = other.gameObject;

        if (gameObject != null)
        {
            if (gameObject.TryGetComponent(out BulletMovement _))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
