using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Item { Score = 0, Shield, Invincible }
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float blinkDuration = 1.0f;
    [SerializeField] private Material[] materials;

    //public float Speed = 10f; // �׽�Ʈ�� 

    //private Rigidbody rigidBody;
    
    private SkinnedMeshRenderer smRenderer;
    Coroutine saveInvincible = null;
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
        Debug.Log(other.transform.name);
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Obstacle")))
        { // ��ֹ��� �ε����� ��
            if (GameManager.isInvincible) // ���� �����϶�
            {
                Debug.Log("�����̶� ���");
                return; // �׳� ��� ��Ų��
            }
            else if (GameManager.isShield) // ���� �����϶�
            {
                GameManager.isShield = false; // ������� false
                Debug.Log("����� ���");
                // �浹�� ��ֹ� �Ѱ� ���������
                // �÷��̾ ����ȭ ��ų ����
            }
            else // ������¿� �������°� off�� ��
            {
                gameObject.SetActive(false);
                //Destroy(gameObject);
                GameManager.isAlive = false;
            }
            return;
        }

        switch (other.transform.tag)
        {
            case "score_item": // ���� �Ծ��� ��
                other.gameObject.SetActive(false); // �浹�� ���� setActive
                GameManager.score += 10; // 10�� �߰�
                break;                
            case "shield_item": // ���� �Ծ��� ��
                other.gameObject.SetActive(false);
                GameManager.isShield = true;
                break;
            case "invincible_item": // ���� ������ �Ծ��� ��
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
        Debug.Log("�������� Ȱ��ȭ");

        //if (!GameManager.isInvincible)
      //  {
            GameManager.isInvincible = true;
            Debug.Log("isInvincible ����");

            for (int i = 0; i < 25; i++)
            {
                smRenderer.material = materials[0];
                yield return new WaitForSeconds(0.1f);
                smRenderer.material = materials[1];
                yield return new WaitForSeconds(0.1f);
            }
         GameManager.isInvincible = false;
        // }

        //GameManager.isInvincible = false;
        yield break;

    }


    
}
