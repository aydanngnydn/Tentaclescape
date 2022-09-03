using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoDestroy : MonoBehaviour
{ 
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
