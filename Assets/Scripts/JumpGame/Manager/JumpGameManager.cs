using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpGameManager : MonoBehaviour
{
    static JumpGameManager jumpGameManager;
    JumpUIManager jumpUIManager;

    public static JumpGameManager Instance { get { return jumpGameManager; } }

    private int currentScore = 0;

    private void Awake()
    {
        jumpGameManager = this;
        jumpUIManager = FindObjectOfType<JumpUIManager>();
    }

    private void Start()
    {
        jumpUIManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("현재점수: " + currentScore);
        jumpUIManager.UpdateScore(currentScore);
    }
}
