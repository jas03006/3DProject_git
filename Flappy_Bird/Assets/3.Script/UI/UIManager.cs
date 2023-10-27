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
            endMenu.gameObject.SetActive(true); // 끝날때 메뉴
        }
        else if (GameManager.isAlive)
        {
            endMenu.gameObject.SetActive(false);
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // pause 기능
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1; // 재개
                pauseMenu.gameObject.SetActive(false); // 퍼즈 메뉴
            }
            else
            {
                Time.timeScale = 0; // 일시정지
                pauseMenu.gameObject.SetActive(true);
            }
        }
    }


}
