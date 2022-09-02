using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Enemy : MonoBehaviour
{
    protected void OnCollisionEnter2D(Collision2D other)
    {
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
