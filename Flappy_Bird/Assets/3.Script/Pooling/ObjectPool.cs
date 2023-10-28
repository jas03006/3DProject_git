using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private float CreatTime = 0f;   // 积己 矫埃
    [SerializeField] private float CreatTimer = 0f;
    [SerializeField] private float height = 0f;
    [SerializeField] private int ObstaclCount;
    public Queue<GameObject> ObstaclPool = new Queue<GameObject>();
    public GameObject Obstacl;

    private void Awake()
    {
        Instancee();
        MakePool();
    }
    private void Start()
    {
        StartMakeObstacl();
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
            GameObject pool;
            if (ObstaclPool.Count == 0)
            {
                //ObstaclPool.Enqueue(pool);
                pool = Instantiate(Obstacl);
            }
            else
            {
                pool = ObstaclPool.Dequeue();
                pool.SetActive(true);
            }
            pool.transform.position = new Vector3(gameObject.transform.position.x, height, gameObject.transform.position.z);

            //ObstaclPool.Enqueue(pool);

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

    private void Instancee()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void StartMakeObstacl()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject a = ObstaclPool.Dequeue();
            a.SetActive(true);
            float speed = a.GetComponent<Object_controll>().GetSpeed();
            a.transform.position = new Vector3(gameObject.transform.position.x- speed * CreatTime * i, height, gameObject.transform.position.z);
        }
    }
}