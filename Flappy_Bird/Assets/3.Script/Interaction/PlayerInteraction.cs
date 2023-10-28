using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Item { Score = 0, Shield, Invincible }
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float blinkDuration = 1.0f;
    [SerializeField] private Material[] materials;

    public float Speed = 10f; // 테스트용 

    private Rigidbody rigidBody;
    
    private SkinnedMeshRenderer smRenderer;
    Coroutine saveInvincible = null;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        smRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
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
        switch (other.transform.name)
        {
            case "Apple": // 코인 먹었을 때
                other.gameObject.SetActive(false); // 충돌한 코인 setActive
                GameManager.score += 10; // 10점 추가
                break;
            case "Mountain": // 장애물에 부딪혔을 때

                if (GameManager.isInvincible) // 무적 상태일때
                {
                    Debug.Log("무적이라 통과");
                    return; // 그냥 통과 시킨다
                }
                else if (GameManager.isShield) // 쉴드 상태일때
                {
                    GameManager.isShield = false; // 쉴드상태 false
                    Debug.Log("쉴드라 통과");
                    // 충돌한 장애물 한개 벗어날때까지
                    // 플레이어를 무적화 시킬 예정
                }
                else // 쉴드상태와 무적상태가 off일 때
                {
                    Destroy(gameObject);
                    GameManager.isAlive = false;
                }
                break;
            case "Gem": // 쉴드 먹었을 때
                other.gameObject.SetActive(false);
                GameManager.isShield = true;
                break;
            case "Star": // 무적 아이템 먹었을 때
                other.gameObject.SetActive(false);

                if (saveInvincible != null)
                {
                    StopCoroutine(saveInvincible);
                }
                saveInvincible = StartCoroutine(OnInvincible());
                break;
            default:
                break;
        }

    }

    IEnumerator OnInvincible()
    {
        Debug.Log("무적상태 활성화");

        //if (!GameManager.isInvincible)
      //  {
            GameManager.isInvincible = true;
            Debug.Log("isInvincible 진입");

            for (int i = 0; i < 25; i++)
            {
                smRenderer.material = materials[0];
                yield return new WaitForSeconds(0.1f);
                smRenderer.material = materials[1];
                yield return new WaitForSeconds(0.1f);
            }
         GameManager.isInvincible = false;
        // }

        GameManager.isInvincible = false;
        yield break;

    }


    
}
