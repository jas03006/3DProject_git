using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum Menus { Main = 0 , Option , Ranking }

public class MainUIManager : MonoBehaviour
{

    [Header("�޴�, �ɼ�")]
    [SerializeField] GameObject[] gameObjects; // ����,�ɼ�
    [SerializeField] Text[] ranktexts;

    [Header("��ŷ")]
    [SerializeField]private JsonExample jsonExample;

    private bool isOption; // �ɼ� Ŭ���ߴ��� üũ�ϱ� ����
    private bool isRanking; // ��ŷ Ŭ���ߴ��� üũ�ϱ� ����

    private void Start()
    {
        jsonExample = FindObjectOfType<JsonExample>();
        isOption = false;
    }

    public void SceneLoad(string scene_name) // ���� ����
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene_name); // MainGame �� �ҷ����� // message
    }

    public void MainOption()
    {
        if (!isOption) // ����
        {
            gameObjects[(int)Menus.Main].SetActive(true); // ���� Ȱ��ȭ
            gameObjects[(int)Menus.Option].SetActive(false); // �ɼ� ��Ȱ��ȭ
            isOption = true; // �ɼ����� ����� bool���� true�� �ٲ�
        }
        else //�ɼ�
        {
            gameObjects[(int)Menus.Main].SetActive(false); // ���� ��Ȱ��ȭ
            gameObjects[(int)Menus.Option].SetActive(true); // �ɼ� Ȱ��ȭ
            isOption = false;
        }
    }

    public void Ranking()
    {
        if (!isRanking) // ����
        {
            gameObjects[(int)Menus.Main].SetActive(true); // ���� Ȱ��ȭ
            gameObjects[(int)Menus.Ranking].SetActive(false); // ��ŷ ��Ȱ��ȭ
            isRanking = true; // ��ŷ���� ����� bool���� true�� �ٲ�
        }

        else // ��ŷ
        {
            PrintRank();
            gameObjects[(int)Menus.Main].SetActive(false); // ���� ��Ȱ��ȭ
            gameObjects[(int)Menus.Ranking].SetActive(true); // �ɼ� Ȱ��ȭ
            isRanking = false;
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
        //1��text : ranktexts[0]
        //2��text : ranktexts[1] 
        //3��text : ranktexts[2]

        jsonExample.jtc = jsonExample.LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
        //for (int i = 0; i < jsonExample.jtc.data.Count; i++)
        for (int i = 0; i < ranktexts.Length && i< jsonExample.jtc.data.Count; i++)
        {
            ranktexts[i].text = $"{i + 1}�� : {jsonExample.jtc.data[i].name} / {jsonExample.jtc.data[i].score}";
        }
    }
}
