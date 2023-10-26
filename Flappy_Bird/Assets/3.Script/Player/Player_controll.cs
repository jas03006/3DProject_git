using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controll : MonoBehaviour
{
    [SerializeField] private float JumpForce = 10f; //점프력

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        PlayerJump();
    }

    private void PlayerJump()   //플레이어 점프
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rigidbody.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
            rigidbody.velocity = Vector3.up * JumpForce;
        }
    }

}
