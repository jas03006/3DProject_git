using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Item { Score = 0, Shield, Invincible }
public class PlayerInteraction : MonoBehaviour
{
    public float Speed = 20f; // �׽�Ʈ�� 
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
            case "Apple": // ���� �Ծ��� ��
                other.gameObject.SetActive(false);
                GameManager.score += 10;
                break;
            case "Obstacle": // ��ֹ��� �ε����� ��
                
                if(GameManager.isInvincible) // ���� �����϶�
                {
                    return; // �׳� ��� ��Ų��
                }
                else if (GameManager.isShield) // ���� �����϶�
                {
                    GameManager.isShield = false; // ������� false
                    // �浹�� ��ֹ� �Ѱ� ���������
                    // �÷��̾ ����ȭ ��ų ����
                }
                else // ������¿� �������°� off�� ��
                {
                    Destroy(gameObject);
                    GameManager.isAlive = false;
                }
                break;
            case "Shield": // ���� �Ծ��� ��
                GameManager.isShield = true;
                break;
            case "Invincible": // ���� ������ �Ծ��� ��
                GameManager.isInvincible = true;
                break;
            default:
                break;
        }
    }

}
