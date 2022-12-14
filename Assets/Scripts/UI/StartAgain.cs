using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartAgain : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    [SerializeField] private Animator playerDeath;
    
    public void Start()
    {
        health.OnPlayerDeath += EndGame;
    }
    public void EndGame()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EndScene");
    }
}
