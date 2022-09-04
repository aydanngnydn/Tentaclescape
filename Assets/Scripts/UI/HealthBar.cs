using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private GameObject[] healths;
    private int index = 0;

    private void Start()
    {
        _playerHealth.OnHealthDecrease += DestroyHealthbar;
    }
    void DestroyHealthbar()
    {
        Destroy(healths[index]);
        index++;
    }
}
