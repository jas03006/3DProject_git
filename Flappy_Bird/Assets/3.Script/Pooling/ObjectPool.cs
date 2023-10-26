using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private float CreatTime = 0f;   // 생성 시간
    private float CreatTimer = 0f;
    [SerializeField] private int ObstaclCount;
    public Queue<GameObject> ObstaclPool = new Queue<GameObject>();
    public GameObject Obstacl;

    private void Awake()
    {
        MakePool();
    }

    private void Update()
    {
        CreatObstacl();
    }

    private void CreatObstacl()
    {
        CreatTimer += Time.deltaTime;
        if (CreatTime < CreatTimer)
        {
            GameObject pool = ObstaclPool.Dequeue();
            if (pool.activeSelf)
            {
                ObstaclPool.Enqueue(pool);

                pool = Instantiate(Obstacl);
            }
            else
            {
                pool.SetActive(true);
            }
            pool.transform.position = new Vector3(0f, UnityEngine.Random.Range(-3f, 3f), 0f); //나오는 위치

            ObstaclPool.Enqueue(pool);

            CreatTimer = 0f;
        }
    }

    private void MakePool() //Pool생성
    {
        for (int i = 0; i < ObstaclCount; i++)
        {
            GameObject gameObject = Instantiate(Obstacl);
            gameObject.SetActive(false);
            ObstaclPool.Enqueue(gameObject);
            
        }
    }
}