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
            Time.timeScale = 0;
            endMenu.gameObject.SetActive(true); // ������ �޴�
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
        if (GameManager.isAlive && Input.GetKeyDown(KeyCode.Escape)) // pause ���
        {
            if (Time.timeScale == 0)
            {
                Debug.Log("����޴� ��Ȱ��ȭ");
                Time.timeScale = 1; // �簳
                pauseMenu.gameObject.SetActive(false); // ���� �޴�
            }
            else
            {
                Debug.Log("����޴� Ȱ��ȭ");
                Time.timeScale = 0; // �Ͻ�����
                pauseMenu.gameObject.SetActive(true);
            }
        }
    }

    public void LoadScene(string str) // �ش� string �� �ε� 
    {
        Debug.Log("dasd");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
        }
        SceneManager.LoadScene(str);
    }

    public void Option(bool check) // �ɼ� �޴�
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

    

   /* public void LoadScene() // �ش� string �� �ε� 
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
