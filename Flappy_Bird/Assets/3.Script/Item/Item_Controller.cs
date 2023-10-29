using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Controller : MonoBehaviour
{
    
    void Start()
    {
        reset();
    }

    public void reset()
    {
        setup(Random.Range(0, transform.childCount));
    }

    public void setup(int index) {
        for (int i =0; i < transform.childCount; i++) {
            Transform now_t = transform.GetChild(i);
            if (i == index)
            {
                now_t.gameObject.SetActive(true);
            }
            else {
                now_t.gameObject.SetActive(false);
            }
        }
    }

    
}
