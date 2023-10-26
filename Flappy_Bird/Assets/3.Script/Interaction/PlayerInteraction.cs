using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Item { Score = 0, Shield, Invincible }
public class PlayerInteraction : MonoBehaviour
{
    public float Speed = 20f; // 테스트용 
    public float jumpForce = 10f; 
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        Move();
        //Jump();
    }

    private void Move()
    {
        rigidBody.velocity = Vector3.right.normalized * Speed;
    }

    //private void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Debug.Log("Space");
    //        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {

        switch(other.transform.name)
        {
            case "Apple": // 코인 먹었을 때
                other.gameObject.SetActive(false);
                GameManager.score += 10;
                break;
            case "Obstacle": // 장애물에 부딪혔을 때
                
                if(GameManager.isInvincible) // 무적 상태일때
                {
                    return; // 그냥 통과 시킨다
                }
                else if (GameManager.isShield) // 쉴드 상태일때
                {
                    GameManager.isShield = false; // 쉴드상태 false
                    // 충돌한 장애물 한개 벗어날때까지
                    // 플레이어를 무적화 시킬 예정
                }
                else // 쉴드상태와 무적상태가 off일 때
                {
                    Destroy(gameObject);
                    GameManager.isAlive = false;
                }
                break;
            case "Shield": // 쉴드 먹었을 때
                GameManager.isShield = true;
                break;
            case "Invincible": // 무적 아이템 먹었을 때
                GameManager.isInvincible = true;
                break;
            default:
                break;
        }
    }

}
