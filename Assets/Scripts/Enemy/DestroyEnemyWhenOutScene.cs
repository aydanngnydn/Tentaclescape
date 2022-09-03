using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyWhenOutScene : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

