using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Item { Score = 0, Shield, Invincible }
public class PlayerInteraction : MonoBehaviour
{
    //[SerializeField] private float blinkDuration = 1.0f;
    [SerializeField] private Material[] materials;
    [SerializeField] private int item_score = 10;

    //public float Speed = 10f; // 테스트용 

    //private Rigidbody rigidBody;
    
    private SkinnedMeshRenderer smRenderer;
    Coroutine saveInvincible = null;
    private GameObject shield_ob;

    private void Awake()
    {
        shield_ob = transform.GetChild(2).gameObject;
        shield_ob.SetActive(false);

    }
    private void Start()
    {
       // rigidBody = GetComponent<Rigidbody>();
        smRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        
    }

    private void Update()
    {

       // Move();
        //Jump();
    }

    private void Move()
    {
       // rigidBody.velocity = Vector3.right.normalized * Speed;
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
        
        //Debug.Log(other.transform.name);
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Obstacle")))
        { // 장애물에 부딪혔을 때
            if (GameManager.isInvincible) // 무적 상태일때
            {
                //Debug.Log("무적이라 통과");
                return; // 그냥 통과 시킨다
            }
            else if (GameManager.isShield) // 쉴드 상태일때
            {
                GameManager.isShield = false; // 쉴드상태 false
                //Debug.Log("쉴드라 통과");
                shield_ob.SetActive(false);
                // 충돌한 장애물 한개 벗어날때까지
                // 플레이어를 무적화 시킬 예정
            }
            else // 쉴드상태와 무적상태가 off일 때
            {
                gameObject.SetActive(false);

                //Destroy(gameObject);
                GameManager.isAlive = false;
            }
            return;
        }

        switch (other.transform.tag)
        {
            case "score_item": // 코인 먹었을 때
                other.transform.parent.gameObject.SetActive(false); // 충돌한 코인 setActive
                ObjectPool.Instance.enqueue_ob(1, other.transform.parent.gameObject);
                GameManager.instance.score += item_score; // 점수 추가
                break;                
            case "shield_item": // 쉴드 먹었을 때
                other.transform.parent.gameObject.SetActive(false);
                ObjectPool.Instance.enqueue_ob(1, other.transform.parent.gameObject);
                GameManager.isShield = true;
                shield_ob.SetActive(true);
                break;
            case "invincible_item": // 무적 아이템 먹었을 때
                other.transform.parent.gameObject.SetActive(false);
                ObjectPool.Instance.enqueue_ob(1, other.transform.parent.gameObject);
                if (saveInvincible != null)
                {
                    StopCoroutine(saveInvincible);
                    smRenderer.material = materials[0];
                }
                saveInvincible = StartCoroutine(OnInvincible());
                break;
            default:
                break;
        }

    }

    IEnumerator OnInvincible()
    {
       //Debug.Log("무적상태 활성화");

        GameManager.isInvincible = true;
        //Debug.Log("isInvincible 진입");

        for (int i = 0; i < 25; i++)
        {
            smRenderer.material = materials[1];
            yield return new WaitForSeconds(0.1f);
            smRenderer.material = materials[0];
            yield return new WaitForSeconds(0.1f);
        }
        GameManager.isInvincible = false;

        yield break;
    }

}
