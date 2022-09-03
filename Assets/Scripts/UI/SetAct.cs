using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetAct : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        Debug.Log("yes");
        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            gameObject.SetActive(true);
        }
    }
}
