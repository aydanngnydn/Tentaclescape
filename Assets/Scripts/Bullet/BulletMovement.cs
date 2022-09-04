using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    public event Action OnBulletStop;

    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float posNeg = (Random.Range(0, 2) * 2 - 1);
        
        float x = Random.Range(0.15f, 0.9f) * posNeg;
        float y = Mathf.Sqrt(1 - x*x) * posNeg;
        
        rb.velocity = new Vector2(x, y) * speed;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            OnBulletStop?.Invoke();
            lastVelocity = rb.velocity;
            rb.velocity = new Vector2(0, 0);
        }
        
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            rb.velocity = lastVelocity;
        }
    }
}
