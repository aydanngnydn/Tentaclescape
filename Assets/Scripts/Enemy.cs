using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject destroyEffect;
    [SerializeField] private float destroyTime;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 contactPoint = other.GetContact(0).point;

        GameObject gameObject = other.gameObject;

        if (gameObject != null)
        {
            if (gameObject.TryGetComponent(out BulletMovement _))
            {
                Destroy(this.gameObject);
                CreateBulletDestroyEffect(contactPoint);
            }
        }
    }
    public void CreateBulletDestroyEffect(Vector2 contactPoint)
    {
        GameObject effect = Instantiate(destroyEffect, contactPoint, Quaternion.identity);
        Destroy(destroyEffect, destroyTime);
    }
}
