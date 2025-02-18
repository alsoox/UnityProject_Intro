using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpGameManager : MonoBehaviour
{
    static JumpGameManager jumpGameManager;
    JumpUIManager jumpUIManager;

    public static JumpGameManager Instance { get { return jumpGameManager; } }

    private int bestScore = 0;
    private int currentScore = 0;
    public bool isGameStarted = false;

    private void Awake()
    {
        jumpGameManager = this;
        jumpUIManager = FindObjectOfType<JumpUIManager>();

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
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
        isGameStarted = false;
        UpdateBestScore();
        jumpUIManager.SetScore(currentScore, bestScore);
        jumpUIManager.ReStartGame();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("현재점수: " + currentScore);
        jumpUIManager.UpdateScore(currentScore);
    }

    private void UpdateBestScore()
    {
        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }
}
