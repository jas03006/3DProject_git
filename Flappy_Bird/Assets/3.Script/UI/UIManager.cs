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
