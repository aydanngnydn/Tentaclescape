using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int contactDamage;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;

    public event Action OnHealthDecrease;
    public event Action OnPlayerDeath;

    public void DecraseHealth(int damage)
    {
        currentHealth -= damage;

        if (!AliveCheck())
        {
            OnPlayerDeath?.Invoke();

            //gameObject.SetActive(false);
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