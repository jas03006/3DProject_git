using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText, gameOver;
    //[SerializeField] private Button restart, toMenu;
    [SerializeField] private GameObject endMenu, optionMenu, pauseMenu;
    [SerializeField] private Image backgroundImage;
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
            Time.timeScale = 0;
            endMenu.gameObject.SetActive(true); // 끝날때 메뉴
        }
        else if (GameManager.isAlive)
        {
           // Time.timeScale = 1;
            endMenu.gameObject.SetActive(false);
        }
    }

    public void restart()
    {
        Time.timeScale = 1;
        endMenu.gameObject.SetActive(false);
        GameManager.isAlive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Pause()
    {
        if (GameManager.isAlive && Input.GetKeyDown(KeyCode.Escape)) // pause 기능
        {
            if (Time.timeScale == 0)
            {
                Debug.Log("퍼즈메뉴 비활성화");
                Time.timeScale = 1; // 재개
                pauseMenu.gameObject.SetActive(false); // 퍼즈 메뉴
            }
            else
            {
                Debug.Log("퍼즈메뉴 활성화");
                Time.timeScale = 0; // 일시정지
                pauseMenu.gameObject.SetActive(true);
            }
        }
    }

    public void LoadScene(string str) // 해당 string 씬 로딩 
    {
        Debug.Log("dasd");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
        }
        SceneManager.LoadScene(str);
    }

    public void Option(bool check) // 옵션 메뉴
    {
        
        if (GameManager.isAlive)
        {
            //Debug.Log("option");
            optionMenu.SetActive(check);
            pauseMenu.SetActive(!check);
        }
        return;
    }

    public void ResumeScene()
    {
        Time.timeScale = 1;
    }

    

   /* public void LoadScene() // 해당 string 씬 로딩 
    {
        Debug.Log("dasd");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
        }
       // SceneManager.LoadScene(str);
    }*/

}
