using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // ���� Message : PlayerManager�� ���� ������ �����
    private static GameManager instance;
    public static int level; // ���̵�
    public static int score; // ���� ���� 
    public static bool isAlive = true; // ����ִ��� Ȯ��
    public static bool isShield = false; // ���� ����
    public static bool isInvincible = false; // ���� ����
    public float timer = 0;
    
    public static GameManager Instance // �̱���
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GameManager>();
            }

            if (instance == null)
            {
                Debug.Log("�̱����� �������� �ʽ��ϴ�.");
            }

            return instance;
        }
    }

    /* ���� -> �̱����� ���� ������ Scene���� Destroy�� �Ͼ
     * UI�� Pause ����� �ߵ��� �ȵǾ� �ּ�ó�� ����.
     */

    //private void Awake() 
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else if (instance != this)
    //    {
    //        Destroy(gameObject);
    //    }

    //    DontDestroyOnLoad(gameObject);

    //}

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f) {
            timer = 0f;
            score += 1;
        }
    }

    private void Init()
    {
     isAlive = true; // ����ִ��� Ȯ��
     isShield = false; // ���� ����
     isInvincible = false; // ���� ����
     level = 0;
     score = 0;
     timer = 0;
    }

    public void LoadScene(string str) // �ش� string �� �ε�
    {
        Init();
        SceneManager.LoadScene(str);
    }

}
