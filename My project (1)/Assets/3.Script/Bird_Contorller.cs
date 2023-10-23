using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Contorller : MonoBehaviour
{
    [SerializeField] private GameObject obstacle_ob;
    private Vector3 dir;
    private Rigidbody bird_r;
    private Vector3 jumpforce;
    // Start is called before the first frame update
    void Awake()
    {
        jumpforce = new Vector3(0, 300f, 0);
        dir = obstacle_ob.transform.position - transform.position;
        dir.y = 0;
        dir = dir.normalized;
        transform.forward = dir;
        TryGetComponent(out bird_r);
        bird_r.AddForce(dir*400f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            //Debug.Log("jump");
            bird_r.AddForce(jumpforce);
        }
        transform.forward = bird_r.velocity.normalized;
        
       // bird_r.MovePosition(transform.position + transform.forward * Time.deltaTime * 60f);
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall")) {
            gameObject.SetActive(false);
        }
    }

}
