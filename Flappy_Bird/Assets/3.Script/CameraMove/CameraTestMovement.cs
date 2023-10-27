using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTestMovement : MonoBehaviour
{
    // Update is called once per frame

    [Header("Movement")]
    [SerializeField]private float moveSpeed = 5f;
    private Rigidbody player_r;
    private void Awake()
    {
        player_r = GetComponent<Rigidbody>();
    }
    void Update()
    {
        InputMove();
    }
    
    private void InputMove()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            player_r.AddForce(0, moveSpeed, 0);
        }
    }
}
