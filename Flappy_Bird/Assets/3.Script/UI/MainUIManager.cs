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

    private bool isOption = false; // �ɼ� Ŭ���ߴ��� üũ�ϱ�����

    private void Start()
    {
        gameObjects = GetComponent<GameObject[]>();
    }



    public void MainStartGame() // ���� ����
    {
        SceneManager.LoadScene("MainGame"); // MainGame �� �ҷ�����
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
        }
    }

    public void MainExit()
    {
        Application.Quit(); // ���� ����
    }
}
