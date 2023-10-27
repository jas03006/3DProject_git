using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Scroll : MonoBehaviour
{
    [SerializeField] private float GroundSpeed = 0;
    private Rigidbody rigidbody;
    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        BackGround_move();
    }
    private void BackGround_move() //¸Ê ¿òÁ÷ÀÓ
    {
        rigidbody.velocity = Vector3.right * GroundSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            this.gameObject.transform.Translate(Vector3.forward * 100f);
        }
    }
}
