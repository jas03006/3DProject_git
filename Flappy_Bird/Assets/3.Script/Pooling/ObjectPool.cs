using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] private float CreatTime = 0f;   // 积己 矫埃
    [SerializeField] private float CreatTimer = 0f;
    [SerializeField] private float height = 0f;
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
            pool.transform.position = new Vector3(gameObject.transform.position.x, height, gameObject.transform.position.z);

            ObstaclPool.Enqueue(pool);

            CreatTimer = 0f;
        }
    }

    private void MakePool() //Pool积己
    {
        for (int i = 0; i < ObstaclCount; i++)
        {
            GameObject gameObject = Instantiate(Obstacl);
            gameObject.SetActive(false);
            ObstaclPool.Enqueue(gameObject);
            
        }
    }
}