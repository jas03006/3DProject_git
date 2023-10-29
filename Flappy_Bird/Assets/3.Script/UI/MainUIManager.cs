using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum Menus { Main = 0 , Option , Ranking }

public class MainUIManager : MonoBehaviour
{

    [Header("메뉴, 옵션")]
    [SerializeField] GameObject[] gameObjects; // 메인,옵션
    [SerializeField] Text[] ranktexts;

    [Header("랭킹")]
    [SerializeField]private JsonExample jsonExample;

    private bool isOption; // 옵션 클릭했는지 체크하기 위해
    private bool isRanking; // 랭킹 클릭했는지 체크하기 위해

    private void Start()
    {
        jsonExample = FindObjectOfType<JsonExample>();
        isOption = false;
    }

    public void SceneLoad(string scene_name) // 게임 시작
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene_name); // MainGame 씬 불러오기 // message
    }

    public void MainOption()
    {
        if (!isOption) // 메인
        {
            gameObjects[(int)Menus.Main].SetActive(true); // 메인 활성화
            gameObjects[(int)Menus.Option].SetActive(false); // 옵션 비활성화
            isOption = true; // 옵션인지 물어보는 bool값을 true로 바꿈
        }
        else //옵션
        {
            gameObjects[(int)Menus.Main].SetActive(false); // 메인 비활성화
            gameObjects[(int)Menus.Option].SetActive(true); // 옵션 활성화
            isOption = false;
        }
    }

    public void Ranking()
    {
        if (!isRanking) // 메인
        {
            gameObjects[(int)Menus.Main].SetActive(true); // 메인 활성화
            gameObjects[(int)Menus.Ranking].SetActive(false); // 랭킹 비활성화
            isRanking = true; // 랭킹인지 물어보는 bool값을 true로 바꿈
        }

        else // 랭킹
        {
            PrintRank();
            gameObjects[(int)Menus.Main].SetActive(false); // 메인 비활성화
            gameObjects[(int)Menus.Ranking].SetActive(true); // 옵션 활성화
            isRanking = false;
        }
    }

    public void ChangeLevel(int levelNum) // 버튼에 int 값 줘서 레벨 조정
    {
        if(GameManager.level > 0 || GameManager.level < 2)
        GameManager.level += levelNum;
    }

    public void ChangeLevelText() // 레벨 텍스트 변환
    {
        switch(GameManager.level)
        {
            case 0:
                FindObjectOfType<Text>().text = "쉬움";
                break;
            case 1:
                FindObjectOfType<Text>().text = "중간";
                break;
            case 2:
                FindObjectOfType<Text>().text = "어려움";
                break;
            default:
                break;
        }
    }

    public void MainExit()
    {
        Application.Quit(); // 게임 종료
    }

    public void PrintRank()
    {
        //1등text : ranktexts[0]
        //2등text : ranktexts[1] 
        //3등text : ranktexts[2]

        jsonExample.jtc = jsonExample.LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
        //for (int i = 0; i < jsonExample.jtc.data.Count; i++)
        for (int i = 0; i < ranktexts.Length && i< jsonExample.jtc.data.Count; i++)
        {
            ranktexts[i].text = $"{i + 1}등 : {jsonExample.jtc.data[i].name} / {jsonExample.jtc.data[i].score}";
        }
    }
}
