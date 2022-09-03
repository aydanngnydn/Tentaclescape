using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{ 
    public void ChangeScene()
    {
        Debug.Log("ttt");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
