using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Item { Score = 0, Shield, Invincible }
public class PlayerInteraction : MonoBehaviour
{
    //[SerializeField] private float blinkDuration = 1.0f;
    [SerializeField] private Material[] materials;
    [SerializeField] private int item_score = 10;

    //public float Speed = 10f; // �׽�Ʈ�� 

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
        { // ��ֹ��� �ε����� ��
            if (GameManager.isInvincible) // ���� �����϶�
            {
                //Debug.Log("�����̶� ���");
                return; // �׳� ��� ��Ų��
            }
            else if (GameManager.isShield) // ���� �����϶�
            {
                GameManager.isShield = false; // ������� false
                //Debug.Log("����� ���");
                shield_ob.SetActive(false);
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
                other.transform.parent.gameObject.SetActive(false); // �浹�� ���� setActive
                ObjectPool.Instance.enqueue_ob(1, other.transform.parent.gameObject);
                GameManager.instance.score += item_score; // ���� �߰�
                break;                
            case "shield_item": // ���� �Ծ��� ��
                other.transform.parent.gameObject.SetActive(false);
                ObjectPool.Instance.enqueue_ob(1, other.transform.parent.gameObject);
                GameManager.isShield = true;
                shield_ob.SetActive(true);
                break;
            case "invincible_item": // ���� ������ �Ծ��� ��
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
       //Debug.Log("�������� Ȱ��ȭ");

        GameManager.isInvincible = true;
        //Debug.Log("isInvincible ����");

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
