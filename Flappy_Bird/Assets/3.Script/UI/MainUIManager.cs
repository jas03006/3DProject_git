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
    [SerializeField] End_Ranking end_ranking;

    [Header("��ŷ")]
    [SerializeField]private JsonExample jsonExample;

    private bool isOption; // �ɼ� Ŭ���ߴ��� üũ�ϱ� ����
    private bool isRanking; // ��ŷ Ŭ���ߴ��� üũ�ϱ� ����

    private void Start()
    {
        jsonExample = FindObjectOfType<JsonExample>();
        isOption = false;
        isRanking = false;
        end_ranking = FindObjectOfType<End_Ranking>();
        end_ranking.gameObject.SetActive(false);
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
            gameObjects[(int)Menus.Main].SetActive(false); // ���� ��Ȱ��ȭ
            gameObjects[(int)Menus.Option].SetActive(true); // �ɼ� Ȱ��ȭ            
            isOption = true; // �ɼ����� ����� bool���� true�� �ٲ�
        }
        else //�ɼ�
        {
            gameObjects[(int)Menus.Main].SetActive(true); // ���� Ȱ��ȭ
            gameObjects[(int)Menus.Option].SetActive(false); // �ɼ� ��Ȱ��ȭ
            isOption = false;
        }
    }

    public void Ranking()
    {
        if (!isRanking) // ����
        {
            end_ranking.PrintRank(false);
            //PrintRank();
            gameObjects[(int)Menus.Main].SetActive(false); // ���� Ȱ��ȭ
            gameObjects[(int)Menus.Ranking].SetActive(true); // ��ŷ ��Ȱ��ȭ
            isRanking = true; // ��ŷ���� ����� bool���� true�� �ٲ�
        }

        else // ��ŷ
        {
            
            gameObjects[(int)Menus.Main].SetActive(true); // ���� ��Ȱ��ȭ
            gameObjects[(int)Menus.Ranking].SetActive(false); // �ɼ� Ȱ��ȭ
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
        const int name_space = 16;
        const int score_space = 8;
        jsonExample.jtc = jsonExample.LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
        //for (int i = 0; i < jsonExample.jtc.data.Count; i++)
        for (int i = 0; i < ranktexts.Length; i++)
        {
            if (i >= jsonExample.jtc.data.Count) {
                ranktexts[i].text = string.Format($"{i + 1}�� : {"",name_space} / {"",score_space}");
                continue;
            }
            string name_length = (name_space - jsonExample.jtc.data[i].name.Length*3).ToString();
            string score_length = (score_space - jsonExample.jtc.data[i].score.ToString().Length).ToString() ;
           //ranktexts[i].text = string.Format($"{i + 1}�� : {jsonExample.jtc.data[i].name,word_space } / {jsonExample.jtc.data[i].score,word_space}");
           ranktexts[i].text = string.Format("{0}�� : {1, "+ name_length + " } / {2, "+ score_length + "}", i+1, jsonExample.jtc.data[i].name, jsonExample.jtc.data[i].score);
        }
    }
}
