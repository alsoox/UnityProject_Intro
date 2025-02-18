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
    public bool isGameStarted = false;

    private void Awake()
    {
        jumpGameManager = this;
        jumpUIManager = FindObjectOfType<JumpUIManager>();
    }

    private void Update()
    {
        if (!isGameStarted) return;
    }

    public void StartGame()
    {
        isGameStarted = true;
        jumpUIManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");

    }

    public void Dead()
    {
        isGameStarted = false;
        jumpUIManager.ReStartGame();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("현재점수: " + currentScore);
        jumpUIManager.UpdateScore(currentScore);
    }
}
