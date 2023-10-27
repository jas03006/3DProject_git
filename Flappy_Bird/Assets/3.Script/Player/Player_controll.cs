using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controll : MonoBehaviour
{
    [SerializeField] private float JumpForce = 10f; //������
    [SerializeField] private int PlayerNum = 0;

    private Rigidbody[] rigidbody;

    private void Start()
    {
        rigidbody = GetComponentsInChildren<Rigidbody>();
    }


    private void Update()
    {
        PlayerJump();
    }

    private void PlayerJump()   //�÷��̾� ����
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rigidbody.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
            rigidbody[PlayerNum].velocity = Vector3.up * JumpForce;
        }
    }

}
