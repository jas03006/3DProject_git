using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_controll : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; 
    [SerializeField] private Rigidbody[] rigidbody;
    private ObjectPool objectPool;
    private void Awake()
    {
        rigidbody = GetComponentsInChildren<Rigidbody>();
        objectPool = GetComponent<ObjectPool>();
    }


    private void Update()
    {
        ObstacleMove();   //장애물 이동
    }

    private void ObstacleMove()  
    {
        rigidbody[0].velocity = Vector3.right * -moveSpeed;
    }
    private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            this.gameObject.SetActive(false);
            ObjectPool.Instance.ObstaclPool.Enqueue(gameObject);
        }
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }
}
