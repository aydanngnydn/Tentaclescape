using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    void Start()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
