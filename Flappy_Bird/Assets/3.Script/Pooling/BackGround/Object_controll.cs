using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_controll : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; 
    [SerializeField] private Rigidbody[] rigidbody_;
    [SerializeField] private int id = 0;
    private ObjectPool objectPool;
    private void Awake()
    {
        rigidbody_ = GetComponentsInChildren<Rigidbody>();
        objectPool = GetComponent<ObjectPool>();
    }


    private void Update()
    {
        ObstacleMove();   //장애물 이동
    }

    private void ObstacleMove()  
    {
        rigidbody_[0].velocity = Vector3.right * -moveSpeed;
    }
    private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            this.gameObject.SetActive(false);
            ObjectPool.Instance.enqueue_ob(id, gameObject);
        }
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }
}
