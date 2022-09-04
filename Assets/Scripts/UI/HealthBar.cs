using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private GameObject[] healths;
    private int index = 0;

    private void OnEnable()
    {
        _playerHealth.OnHealthDecrease += DestroyHealthbar;
        _playerHealth.OnPlayerDeath += DestroyHealthbar;
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthDecrease -= DestroyHealthbar;
        _playerHealth.OnPlayerDeath -= DestroyHealthbar;
    }
    void DestroyHealthbar()
    {
        Destroy(healths[index]);
        index++;
    }
}
