using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float x = Random.Range(0.1f, 1.0f);
        float y = Mathf.Sqrt(1 - x*x);
        rb.velocity = new Vector2(x, y) * speed;
    }
}
