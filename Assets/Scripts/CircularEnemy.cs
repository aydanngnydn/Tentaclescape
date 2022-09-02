using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularEnemy : Enemy
{
    public float angularSpeed = 1f;
    public float circleRad = 1f;

    private float currentAngle;

    [SerializeField] private float xSpeed;

    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    void Update()
    {

        currentAngle += angularSpeed * Time.deltaTime;
        Vector2 offset = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * circleRad;

        if (pos.x > 0)
        {
            transform.Translate(-(offset + new Vector2(xSpeed, 0)) * Time.deltaTime);
        }
        else if (pos.x < 0)
        {
            transform.Translate((offset + new Vector2(xSpeed, 0)) * Time.deltaTime);

        }
    }
}