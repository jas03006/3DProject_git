using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum Menus { Main = 0 , Option }

public class MainUIManager : MonoBehaviour
{

    [Header("메뉴, 옵션")]
    [SerializeField] GameObject[] gameObjects; // 메인,옵션
    [SerializeField] Text[] Ranktexts;

    private bool isOption; // 옵션 클릭했는지 체크하기위해

    private void Start()
    {
        isOption = false;

    }

    public void MainStartGame() // 게임 시작
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // MainGame 씬 불러오기 // message
    }

    public void MainOption()
    {
        if(!isOption) // 메인일 때
        {
            gameObjects[(int)Menus.Main].SetActive(true); // 옵션 활성화
            gameObjects[(int)Menus.Option].SetActive(false); // 메인 비활성화
            isOption = true; // 옵션인지 물어보는 bool값을 true로 바꿈
        }
        else // 옵션인지 물어보는 bool값이 true일 때
        {
            gameObjects[(int)Menus.Main].SetActive(false); // 옵션 비활성화
            gameObjects[(int)Menus.Option].SetActive(true); // 메인 활성화
            isOption = false;
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
    
    }
}
