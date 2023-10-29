using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controll : MonoBehaviour
{
    [SerializeField] private float JumpForce = 10f; //점프력
    [SerializeField] private int PlayerNum = 0;

    [SerializeField] private AudioClip flap_clip;

    private Rigidbody rigidbody_;
    private AudioSource audio_source;

    private void Start()
    {        
        TryGetComponent(out audio_source);
        set_player();
        //rigidbody = GetComponentsInChildren<Rigidbody>();
    }


    private void Update()
    {
        PlayerJump();
    }

    public int get_PlayerNum() {
        return PlayerNum;
    }
    private void set_player() {
        if (PlayerPrefs.HasKey("Info"))
        {
            PlayerNum = PlayerPrefs.GetInt("Info");
        }
        else
        {
            PlayerNum = Random.Range(0, transform.childCount);
        }
        for (int i =0; i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i==PlayerNum);
        }
        rigidbody_ = transform.GetChild(PlayerNum).gameObject.GetComponent<Rigidbody>();
    }

    private void PlayerJump()   //플레이어 점프
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody_.AddForce(Vector3.up * get_force_adjustment(rigidbody_.velocity.y) * JumpForce,ForceMode.Impulse );
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
        return rigidbody_.transform;
    }
}
