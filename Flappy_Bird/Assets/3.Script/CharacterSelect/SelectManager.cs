using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    #region 스케치
    /*
    <캐릭터 선택 창 만들기>

    //변수
        //캐릭터 오브젝트 배열
        //인덱스 번호

    //메서드
        //업데이트
            -> 입력받기
            -> 엔터키 누르면 선택하기
        //입력받기
            -> 오른쪽 방향키 누르면 넘어가기(인덱스+1)
            -> 왼쪽 방향키 누르면 넘어가기(인덱스-1)
        //넘어가기
            -> 기존에 켜져있는 오브젝트 비활성화하기
            -> 인덱스 안에 있는 오브젝트 활성화하기
        //최종 선택하기
            -> 현재 활성화되어 있는 캐릭터 인덱스 넘겨주기

    //추가 공유 사항
        //컴퓨터 방향키, 엔터키로 구현함
        //[1027] 컴퓨터 방향키, 엔터키 구현 -> 버튼 구현으로 수정
     */
    #endregion

    [Header("캐릭터 선택")]
    [SerializeField] private GameObject[] characters; //캐릭터 오브젝트 배열
    private int index = 0; //인덱스 번호
    private BGM_Player bgm_player;
    private void Start()
    {
        characters[0].gameObject.SetActive(true); //첫번째 캐릭터 활성화
        for (int i = 1; i < characters.Length; i++)
        {
            characters[i].gameObject.SetActive(false); //그 외 비활성화
        }

        bgm_player = FindObjectOfType<BGM_Player>();
    }

    private void Update()
    {
        //엔터키 누르면 선택하기
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Selected();
        }
    }

    public void InputButton_R()
    {
        index++;
        index %= characters.Length;
        CharActive();
    }

    public void InputButton_L()
    {
        index--;
        index += characters.Length;
        index %= characters.Length;
        CharActive();
    }

    private void CharActive()//넘어가기
    {
        //기존에 켜져있는 오브젝트 비활성화하기
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].activeSelf)
            {
                characters[i].SetActive(false);
                break;
            }
        }

        //인덱스 안에 있는 오브젝트 활성화하기
        characters[index].SetActive(true);
    }

    public void Selected()//최종 선택하기
    {
        //현재 활성화되어 있는 캐릭터 인덱스 PlayerPrefs 저장
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].activeSelf)
            {
                PlayerPrefs.SetInt("Info", i);
                break;
            }
        }
        Destroy(bgm_player.gameObject);
        //다음 씬으로 넘기기
        SceneManager.LoadScene("MainGame");
    }


}
