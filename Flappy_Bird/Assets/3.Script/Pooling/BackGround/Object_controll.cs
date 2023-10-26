using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_controll : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; 
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        ObstacleMove();   //��ֹ� �̵�
    }

    private void ObstacleMove()  
    {
        rigidbody.velocity = Vector3.right * -moveSpeed;
    }
}
