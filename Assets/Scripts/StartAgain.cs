using UnityEngine;
using UnityEngine.SceneManagement;
public class StartAgain : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    public void Start()
    {
        health.OnPlayerDeath += EndGame;
    }
    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }
}
