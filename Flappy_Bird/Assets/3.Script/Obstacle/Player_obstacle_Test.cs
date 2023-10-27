using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_obstacle_Test : MonoBehaviour
{ 
    private void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> list = new List<ParticleSystem.Particle>();
        ParticleSystem ps =gameObject.GetComponent<ParticleSystem>();
        if (ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, list, out ParticleSystem.ColliderData cd) > 0) {
            Debug.Log(cd.GetColliderCount(0));
            Debug.Log(cd.GetCollider(0, 0).gameObject.name);
            for (int p = 0; p < list.Count; p++) {
                for (int i = 0; i < cd.GetColliderCount(p); i++)
                {
                    GameObject ob = cd.GetCollider(p, i).gameObject;
                    if (ob.CompareTag("Player"))
                    {
                        ob.SetActive(false);
                    }
                }
            }
        }
    }
}
