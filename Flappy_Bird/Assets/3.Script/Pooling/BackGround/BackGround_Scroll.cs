using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Scroll : MonoBehaviour
{
    [SerializeField] private float GroundSpeed = 0;
    private Rigidbody rigidbody_;
    private Collider collider_;
    

    private void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody>();
        collider_ = GetComponentInChildren<MeshCollider>();
    }
    private void Update()
    {
        BackGround_move();
    }
    private void BackGround_move() //¸Ê ¿òÁ÷ÀÓ
    {
        rigidbody_.velocity = Vector3.right * GroundSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            this.gameObject.transform.Translate(Vector3.forward * collider_.bounds.size.x*0.9f * 5);
        }
    }
}
