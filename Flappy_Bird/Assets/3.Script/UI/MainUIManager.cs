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

    private bool isOption = false; // 옵션 클릭했는지 체크하기위해

    private void Start()
    {
        gameObjects = GetComponent<GameObject[]>();
    }



    public void MainStartGame() // 게임 시작
    {
        SceneManager.LoadScene("MainGame"); // MainGame 씬 불러오기
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
        }
    }

    public void MainExit()
    {
        Application.Quit(); // 게임 종료
    }
}
