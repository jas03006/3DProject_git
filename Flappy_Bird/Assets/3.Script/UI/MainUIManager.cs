using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum Menus { Main = 0 , Option }

public class MainUIManager : MonoBehaviour
{

    [Header("�޴�, �ɼ�")]
    [SerializeField] GameObject[] gameObjects; // ����,�ɼ�
    [SerializeField] Text[] Ranktexts;

    private bool isOption; // �ɼ� Ŭ���ߴ��� üũ�ϱ�����

    private void Start()
    {
        isOption = false;

    }

    public void MainStartGame() // ���� ����
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // MainGame �� �ҷ����� // message
    }

    public void MainOption()
    {
        if(!isOption) // ������ ��
        {
            gameObjects[(int)Menus.Main].SetActive(true); // �ɼ� Ȱ��ȭ
            gameObjects[(int)Menus.Option].SetActive(false); // ���� ��Ȱ��ȭ
            isOption = true; // �ɼ����� ����� bool���� true�� �ٲ�
        }
        else // �ɼ����� ����� bool���� true�� ��
        {
            gameObjects[(int)Menus.Main].SetActive(false); // �ɼ� ��Ȱ��ȭ
            gameObjects[(int)Menus.Option].SetActive(true); // ���� Ȱ��ȭ
            isOption = false;
        }
    }

    public void ChangeLevel(int levelNum) // ��ư�� int �� �༭ ���� ����
    {
        if(GameManager.level > 0 || GameManager.level < 2)
        GameManager.level += levelNum;
    }

    public void ChangeLevelText() // ���� �ؽ�Ʈ ��ȯ
    {
        switch(GameManager.level)
        {
            case 0:
                FindObjectOfType<Text>().text = "����";
                break;
            case 1:
                FindObjectOfType<Text>().text = "�߰�";
                break;
            case 2:
                FindObjectOfType<Text>().text = "�����";
                break;
            default:
                break;
        }
    }

    public void MainExit()
    {
        Application.Quit(); // ���� ����
    }

    public void PrintRank()
    {
    
    }
}
