using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BrainCamera : MonoBehaviour
{
    #region 스케치
    /*
    <캐릭터 선택 창 만들기>

    //변수
        //가상 카메라 오브젝트 배열
        //인덱스 번호

    //메서드
        //업데이트
            -> 입력받기
        //입력받기
            -> 1,2,3 입력받기
        //카메라 변경하기(index 활용)
            -> 카메라 변경하기

    //추가 공유 사항
        //vCam1 : 백뷰
        //vCam2 : 1인칭 시점
        //vCam3 : 사이드뷰
        //[1027] 컴퓨터 방향키, 엔터키 구현 -> 버튼 구현으로 수정
     */

    #endregion

    [Header("카메라 시점이동")]
    [SerializeField] private GameObject[] vCams;//가상 카메라 오브젝트 배열
    private int index = 0; //인덱스 번호

    private void Awake()
    {
    }

    void Start()
    {
        SelectCam();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            index = 0;
            SelectCam();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            index = 1;
            SelectCam();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            index = 2;
            SelectCam();
        }
    }

    private void SelectCam()
    {
        for (int i = 0; i < vCams.Length; i++)
        {
            if (i == index)
            {
                vCams[i].SetActive(true);
            }
            else
            {
                vCams[i].SetActive(false);
            }
        }
    }
}
