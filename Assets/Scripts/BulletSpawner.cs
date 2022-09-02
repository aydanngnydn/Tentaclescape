using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    void Start()
    {
        float randomSpawnDegree = Random.Range(0, 360);
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, randomSpawnDegree)));
    }
    void Update()
    {
        
    }
}
