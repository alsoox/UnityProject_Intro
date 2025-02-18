using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpUIManager : MonoBehaviour
{
    public Text scoreText;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
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
