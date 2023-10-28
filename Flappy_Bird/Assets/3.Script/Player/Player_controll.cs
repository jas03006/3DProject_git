using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controll : MonoBehaviour
{
    [SerializeField] private float JumpForce = 10f; //점프력
    [SerializeField] private int PlayerNum = 0;

    [SerializeField] private AudioClip flap_clip;

    private Rigidbody[] rigidbody;
    private AudioSource audio_source;

    private void Start()
    {
        rigidbody = GetComponentsInChildren<Rigidbody>();
        TryGetComponent(out audio_source);
    }


    private void Update()
    {
        PlayerJump();
    }

    private void PlayerJump()   //플레이어 점프
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody[PlayerNum].AddForce(Vector3.up * get_force_adjustment(rigidbody[PlayerNum].velocity.y) * JumpForce,ForceMode.Impulse );
            audio_source.PlayOneShot(flap_clip);
            //rigidbody[PlayerNum].velocity = Vector3.up * JumpForce;
        }
    }

    private float get_force_adjustment(float speed) {
        if (speed <= 0) {
            return 1;
        }
        return 1 / Mathf.Abs(speed/2f + 1);
    }

    public Transform get_now_player() {
        return rigidbody[PlayerNum].transform;
    }
}
