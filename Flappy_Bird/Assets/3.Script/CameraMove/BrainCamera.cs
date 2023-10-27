using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BrainCamera : MonoBehaviour
{
    #region ����ġ
    /*
    <ĳ���� ���� â �����>

    //����
        //���� ī�޶� ������Ʈ �迭
        //�ε��� ��ȣ

    //�޼���
        //������Ʈ
            -> �Է¹ޱ�
        //�Է¹ޱ�
            -> 1,2,3 �Է¹ޱ�
        //ī�޶� �����ϱ�(index Ȱ��)
            -> ī�޶� �����ϱ�

    //�߰� ���� ����
        //vCam1 : ���
        //vCam2 : 1��Ī ����
        //vCam3 : ���̵��
        //[1027] ��ǻ�� ����Ű, ����Ű ���� -> ��ư �������� ����
     */

    #endregion

    [Header("ī�޶� �����̵�")]
    [SerializeField] private GameObject[] vCams;//���� ī�޶� ������Ʈ �迭
    private int index = 0; //�ε��� ��ȣ

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
