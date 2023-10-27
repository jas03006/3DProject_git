using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Lower : MonoBehaviour
{
    [SerializeField] private float[] y_scale;
    [SerializeField] private GameObject fire_buff;
    public void set_fire_height(int num) {
        fire_buff.SetActive(false);
        fire_buff.transform.localScale = new Vector3(
            fire_buff.transform.localScale.x,
            y_scale[num],
            fire_buff.transform.localScale.z);
        fire_buff.SetActive(true);
    }
}
