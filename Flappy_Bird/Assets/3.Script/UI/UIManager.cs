using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text scoreText, gameOver;
    public Button restart, toMenu;
    public GameObject endMenu, pauseMenu;
    private void Update()
    {
        ShowScore(); // 현재 점수 UI
        UITrigger(); // 게임 엔딩 시 표기하는 UI
        Pause(); // 일시정지 기능
    }
    
    private void ShowScore()
    {
        scoreText.text = $"Score : {GameManager.score}";
    }

    private void UITrigger()
    {
        if (!GameManager.isAlive)
        {
            endMenu.gameObject.SetActive(true);
            //gameOver.gameObject.SetActive(true);
            //restart.gameObject.SetActive(true);
            //toMenu.gameObject.SetActive(true);
        }
        else if (GameManager.isAlive)
        {
            endMenu.gameObject.SetActive(false);
            //gameOver.gameObject.SetActive(false);
            //restart.gameObject.SetActive(false);
            //toMenu.gameObject.SetActive(false);
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // pause 기능
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1; // 재개
                pauseMenu.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0; // 일시정지
                pauseMenu.gameObject.SetActive(true);
            }
        }
    }


}
