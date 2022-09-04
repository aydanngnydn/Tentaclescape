using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int contactDamage;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    private Collider2D collider;

    public event Action OnHealthDecrease;
    public event Action OnPlayerDeath;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    public void DecraseHealth(int damage)
    {
        currentHealth -= damage;

        if (!AliveCheck())
        {
            OnPlayerDeath?.Invoke();
            Destroy(collider);
            Destroy(gameObject, 0.5f);
        }
        else
        {
            OnHealthDecrease?.Invoke();
        }
    }

    public bool AliveCheck()
    {
        return currentHealth > 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject gameObject = other.gameObject;

        if (gameObject != null)
        {
            if (gameObject.TryGetComponent(out Enemy enemy))
            {
                DecraseHealth(contactDamage);
            }

            else if (gameObject.TryGetComponent(out BulletMovement _))
            {
                DecraseHealth(contactDamage);
            }
        }
        else
        {
            Debug.Log("There is no gameObject this" + name + "collides.");
        }
    }
}