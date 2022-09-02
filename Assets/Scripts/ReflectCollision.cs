using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCollision : MonoBehaviour
{
   private Rigidbody2D rb;
   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
   }

   private void OnCollisionEnter2D(Collision2D col)
   {
      var speed = rb.velocity.magnitude;
      var direction = Vector3.Reflect(rb.velocity.normalized, col.contacts[0].normal);
      rb.velocity = direction * speed;
      Debug.Log(rb.velocity);
   }
}
