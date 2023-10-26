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
        ObstacleMove();   //장애물 이동
    }

    private void ObstacleMove()  
    {
        rigidbody.velocity = Vector3.right * -moveSpeed;
    }
}
