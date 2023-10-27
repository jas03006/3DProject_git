using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Upper : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacle_prefabs;
    //private int player_id = 0;
    private List<Transform> pos_list;

    private void Awake()
    {
        pos_list = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++) {
            pos_list.Add(transform.GetChild(i));
        }
        
    }

    public void init(int player)
    {
        obstacle_prefabs.RemoveAt(player);
        
        for (int i =0; i < pos_list.Count; i++) {                        
            for (int j =0; j < obstacle_prefabs.Count; j++) {
                GameObject ob = Instantiate(obstacle_prefabs[j], pos_list[i].position, pos_list[i].rotation);
                ob.transform.SetParent(pos_list[i]);
                ob.SetActive(false);
            }            
        }
    }

    public void set_obstacle_count(int obstacle_count)
    {
        int count = obstacle_count;
        if (count < 0) {
            count = 0;
        } else if (count > pos_list.Count) {
            count = pos_list.Count;
        }

        int now_id = 0;
        for (int i = 0; i < pos_list.Count; i++)
        {
            Transform pos = pos_list[i];
            if (i < count)
            {
                pos.gameObject.SetActive(true);
            }
            else {
                pos.gameObject.SetActive(false);
                continue;
            }
                       
            now_id = Random.Range(0, pos.childCount);
            for (int j = 0; j < pos.childCount; j++)
            {
                if (j != now_id)
                {
                    pos.GetChild(j).gameObject.SetActive(false);
                }
                else {
                    pos.GetChild(j).gameObject.SetActive(true);
                }
            }      
        }
    }

}
