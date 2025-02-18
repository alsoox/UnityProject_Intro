using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpUIManager : MonoBehaviour
{
    public Text scoreText;
    public Text currentScore;
    public Text bestScore;
    public Button startButton;
    public Button restartButtom;
    public Button exitButtom;

    public GameObject startGame;
    public GameObject restartGame;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        restartButtom.onClick.AddListener(ReStartGameButton);
        exitButtom.onClick.AddListener(ExitMinGame);
        startGame.SetActive(true);
        restartGame.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetScore(int _currentScore, int _bestScore)
    {
        currentScore.text = _currentScore.ToString();
        bestScore.text = _bestScore.ToString();
    }

    public void StartGame()
    {
        JumpGameManager.Instance.StartGame();
        startGame.SetActive(false);
    }

    public void ReStartGame()
    {
        restartGame.SetActive(true);
    }

    public void ReStartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitMinGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    
}
