using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularEnemy : MonoBehaviour
{
    public float angularSpeed = 1f;
    public float circleRad = 1f;
 
    private Vector2 fixedPoint;
    private float currentAngle;

    [SerializeField] private float xSpeed;
 
    void Start ()
    {
        fixedPoint = transform.position;
    }
 
    void Update ()
    {
        currentAngle += angularSpeed * Time.deltaTime;
        Vector2 offset = new Vector2 (Mathf.Sin (currentAngle), Mathf.Cos (currentAngle)) * circleRad;
        transform.Translate( (offset + new Vector2(xSpeed, 0)) * Time.deltaTime);
    }
}
