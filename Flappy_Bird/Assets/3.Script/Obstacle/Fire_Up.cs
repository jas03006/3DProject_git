using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Up : MonoBehaviour
{
    private ParticleSystem ps;
    private BoxCollider collider;
    private AudioSource audio_source;
    private void Start()
    {
        TryGetComponent(out ps);
        TryGetComponent(out collider);
        TryGetComponent(out audio_source);
    }

    private void Update()
    {        
        if (ps.particleCount >0 )
        {
            collider.enabled = true;
            //audio_source.Play();
        }
        else {
            collider.enabled = false;
            //audio_source.Stop();
        }
    }


}
