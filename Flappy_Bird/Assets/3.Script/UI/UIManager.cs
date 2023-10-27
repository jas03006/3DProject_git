using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText, gameOver;
    [SerializeField] private Button restart, toMenu;
    [SerializeField] private GameObject endMenu, pauseMenu;
    private void Update()
    {
        ShowScore(); // ���� ���� UI
        UITrigger(); // ���� ���� �� ǥ���ϴ� UI
        Pause(); // �Ͻ����� ���
    }
    
    private void ShowScore()
    {
        scoreText.text = $"Score : {GameManager.score}";
    }

    private void UITrigger()
    {
        if (!GameManager.isAlive)
        {
            endMenu.gameObject.SetActive(true); // ������ �޴�
        }
        else if (GameManager.isAlive)
        {
            endMenu.gameObject.SetActive(false);
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // pause ���
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1; // �簳
                pauseMenu.gameObject.SetActive(false); // ���� �޴�
            }
            else
            {
                Time.timeScale = 0; // �Ͻ�����
                pauseMenu.gameObject.SetActive(true);
            }
        }
    }


}
