using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float xAxisSpeed;
    void FixedUpdate()
    {
        transform.Translate(new Vector2(xAxisSpeed * Time.fixedDeltaTime, 0));
    }
}
