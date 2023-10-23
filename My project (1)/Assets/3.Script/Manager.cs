using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject obstacle_prefab;
    private float distance = 20f;
    private float generation_cnt = 10f;
    private float timer = 0f;
    private List<GameObject> obstacle_list;
    private int index = 0;
    private Transform parent;

    private float original_y;
    private float min_y = -6f;
    private float max_y = 6f;
    // Start is called before the first frame update
    void Start()
    {
        obstacle_list = new List<GameObject>();
        timer = 0f;
        index = 0;
        parent = transform.parent;
        original_y = parent.position.y;
        for (int i =0; i < generation_cnt; i++) {
            obstacle_list.Add(Instantiate(obstacle_prefab, parent.position + (parent.forward * distance * (i+1)) + Vector3.up * get_random_y_sin(), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f) {
            timer = 0f;
            obstacle_list[index].transform.position = new Vector3(transform.position.x, original_y, transform.position.z)  + (parent.forward * distance * generation_cnt) + Vector3.up * get_random_y_sin();
            index++;
            index %= obstacle_list.Count;
        }
    }

    public float get_random_y_sin() {
         return (1+Mathf.Cos(Random.Range(0, Mathf.PI)))/2f*(max_y-min_y) +min_y;
        //return Random.Range(min_y, max_y);
    }
}
