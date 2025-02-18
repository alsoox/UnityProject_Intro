using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeechBubble : MonoBehaviour
{
    public GameObject speechBubble;
    private bool isPlayerInRange = false;


    private void Awake()
    {
    }

    private void Start()
    {
        if (speechBubble != null) speechBubble.SetActive(false);

    }

   
    private void Update()
    {
        //Trigger 범위 안이고 F 를 누르면 미니게임 시작
        if (isPlayerInRange = true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("미니게임을 시작합니다.");
            SceneManager.LoadScene("JumpGame");
        }
    }

    //플레이어가 Trigger 범위 안에 들어 왔을 때 말풍선 활성화
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (speechBubble != null)
            {
                speechBubble.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (speechBubble != null)
            {
                speechBubble.SetActive(false);
            }
        }
    }
}
