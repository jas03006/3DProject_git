using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Up : MonoBehaviour
{
    private ParticleSystem ps;
    private BoxCollider collider;
    private void Start()
    {
        TryGetComponent(out ps);
        TryGetComponent(out collider);
        
    }

    private void Update()
    {
        
        if (ps.particleCount >0 )
        {
            collider.enabled = true;
           // Debug.Log(ps.particleCount);
        }
        else {
            collider.enabled = false;
        }
    }


}
