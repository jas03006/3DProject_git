using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text scoreText, gameOver;
    public Button restart, toMenu;

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
            gameOver.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            toMenu.gameObject.SetActive(true);
        }
        else if (GameManager.isAlive)
        {
            gameOver.gameObject.SetActive(false);
            restart.gameObject.SetActive(false);
            toMenu.gameObject.SetActive(false);
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // pause ���
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1; // �簳
            }
            else
            {
                Time.timeScale = 0; // �Ͻ�����
            }
        }
    }


}
