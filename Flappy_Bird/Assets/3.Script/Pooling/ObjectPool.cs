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
    [SerializeField] private int ItemCount;
    
    public Queue<GameObject> ObstaclPool = new Queue<GameObject>();
    public Queue<GameObject> ItemPool = new Queue<GameObject>();



    public GameObject Obstacl;
    public GameObject ItemPrefabs;

    private void Awake()
    {

        Instancee();
        MakePool();
        MakeItempool();
    }
    private void Start()
    {
        StartMakeObstacl();
    }
    private void Update()
    {
        CreatObstacl();
        //CreatItem();
    }



    private void CreatObstacl()
    {
        CreatTimer += Time.deltaTime;
        if (CreatTime < CreatTimer)
        {
            GameObject pool;
//            GameObject itempool;

            if (ObstaclPool.Count == 0)
            {
                //obstaclPool.Enqueue(pool);
                pool = Instantiate(Obstacl);
//                itempool = Instantiate(ItemPrefabs);
            }
            else
            {
                pool = ObstaclPool.Dequeue();
                pool.SetActive(true);
//               itempool = ItemPool.Dequeue();
//               itempool.SetActive(true);
            }
            pool.transform.position = new Vector3(gameObject.transform.position.x, height, gameObject.transform.position.z);
            //  itempool.transform.position = new Vector3(gameObject.transform.position.x- 5/2, UnityEngine.Random.Range(-2f, 2f), gameObject.transform.position.z);
            //ObstaclPool.Enqueue(pool);
            float rand_value = Random.Range(0, 1f);
            if (rand_value < 0.5f) {
                CreatItem();
            }            
            CreatTimer = 0f;
        }
    }

    private void CreatItem()
    {
       // CreatTimer += Time.deltaTime;
    /*    if (CreatTime < CreatTimer)
        {*/
            GameObject itempool;

            if (ItemPool.Count == 0)
            {
                //ObstaclPool.Enqueue(pool);
                itempool = Instantiate(ItemPrefabs);
            }
            else
            {
                itempool = ItemPool.Dequeue();
                itempool.SetActive(true);
                //Debug.Log(itempool);
                itempool.GetComponent<Item_Controller>().reset();
            }
        float speed = itempool.GetComponent<Object_controll>().GetSpeed();
        itempool.transform.position = new Vector3(gameObject.transform.position.x - speed * CreatTime/ 2, gameObject.transform.position.y + UnityEngine.Random.Range(-0.8f, 0.8f)* height, gameObject.transform.position.z);
            //ObstaclPool.Enqueue(pool);

            //CreatTimer = 0f;
       // }
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
    private void MakeItempool()
    {
        for (int i = 0; i < ItemCount; i++)
        {
            GameObject game = Instantiate(ItemPrefabs);
            game.SetActive(false);
            ItemPool.Enqueue(game);
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

    public void enqueue_ob(int n, GameObject ob) {
        if (n == 0) {
            ObstaclPool.Enqueue(ob);
        } else if (n == 1) {
            ItemPool.Enqueue(ob);
        }
    }
  
}