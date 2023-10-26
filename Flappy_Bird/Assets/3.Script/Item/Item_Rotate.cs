using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Rotate : MonoBehaviour
{
    [SerializeField] private float rotate_speed = 180f;
    void Update()
    {
        transform.Rotate(transform.up * rotate_speed * Time.deltaTime);
       // transform.RotateAround(transform.position, transform.up, rotate_speed*Time.deltaTime);
    }
}
