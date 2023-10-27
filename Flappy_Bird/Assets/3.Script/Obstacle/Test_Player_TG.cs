using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player_TG : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
