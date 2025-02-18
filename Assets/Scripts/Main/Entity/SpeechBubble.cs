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
        //Trigger ���� ���̰� F �� ������ �̴ϰ��� ����
        if (isPlayerInRange = true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("�̴ϰ����� �����մϴ�.");
            SceneManager.LoadScene("JumpGame");
        }
    }

    //�÷��̾ Trigger ���� �ȿ� ��� ���� �� ��ǳ�� Ȱ��ȭ
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
