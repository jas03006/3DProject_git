using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // 강민 Message : PlayerManager를 따로 만들지 고민중
    private static GameManager instance;
    public static int level; // 난이도
    public static int score; // 현재 점수 
    public static bool isAlive = true; // 살아있는지 확인
    public static bool isShield = false; // 쉴드 상태
    public static bool isInvincible = false; // 무적 상태
    public float timer = 0;
    
    public static GameManager Instance // 싱글톤
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GameManager>();
            }

            if (instance == null)
            {
                Debug.Log("싱글톤이 존재하지 않습니다.");
            }

            return instance;
        }
    }

    /* 강민 -> 싱글톤을 쓰려 했으나 Scene에서 Destroy가 일어나
     * UI와 Pause 기능이 발동이 안되어 주석처리 했음.
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
     isAlive = true; // 살아있는지 확인
     isShield = false; // 쉴드 상태
     isInvincible = false; // 무적 상태
     level = 0;
     score = 0;
     timer = 0;
    }

    public void LoadScene(string str) // 해당 string 씬 로딩
    {
        Init();
        SceneManager.LoadScene(str);
    }

}
