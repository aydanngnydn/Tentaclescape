using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    [SerializeField] private float maxDistanceFromStart;
    [SerializeField] private float enemyXAxisSpeed;
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    private void Update()
    {
        if (pos.x > 0)
        {
            transform.Translate(new Vector2(- enemyXAxisSpeed * Time.fixedDeltaTime, Mathf.Sin(Time.realtimeSinceStartup) * maxDistanceFromStart));
        }
        else if (pos.x < 0)
        {
            transform.Translate(new Vector2(enemyXAxisSpeed * Time.fixedDeltaTime, Mathf.Sin(Time.realtimeSinceStartup) * maxDistanceFromStart));
        }
        
    }
}
