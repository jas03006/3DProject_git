using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    #region ����ġ
    /*
    <ĳ���� ���� â �����>

    //����
        //ĳ���� ������Ʈ �迭
        //�ε��� ��ȣ

    //�޼���
        //������Ʈ
            -> �Է¹ޱ�
            -> ����Ű ������ �����ϱ�
        //�Է¹ޱ�
            -> ������ ����Ű ������ �Ѿ��(�ε���+1)
            -> ���� ����Ű ������ �Ѿ��(�ε���-1)
        //�Ѿ��
            -> ������ �����ִ� ������Ʈ ��Ȱ��ȭ�ϱ�
            -> �ε��� �ȿ� �ִ� ������Ʈ Ȱ��ȭ�ϱ�
        //���� �����ϱ�
            -> ���� Ȱ��ȭ�Ǿ� �ִ� ĳ���� �ε��� �Ѱ��ֱ�

    //�߰� ���� ����
        //��ǻ�� ����Ű, ����Ű�� ������ 
     */
    #endregion

    [Header("ĳ���� ����")]
    [SerializeField] private GameObject[] characters; //ĳ���� ������Ʈ �迭
    private int index = 0; //�ε��� ��ȣ

    private void Start()
    {
        characters[0].gameObject.SetActive(true); //ù��° ĳ���� Ȱ��ȭ
        for (int i = 1; i < characters.Length; i++)
        {
            characters[i].gameObject.SetActive(false); //�� �� ��Ȱ��ȭ
        }
    }

    private void Update()
    {
        //�Է¹ޱ�
        InputKey();

        //����Ű ������ �����ϱ�
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Selected();
        }
    }

    private void InputKey() //�Է¹ޱ�
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) //������ ����Ű ������ �Ѿ��(�ε���+1)
        {
            index++;
            index %= characters.Length;
            CharActive();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) // ���� ����Ű ������ �Ѿ��(�ε���-1)
        {
            index--;
            index += characters.Length;
            index %= characters.Length;
            CharActive();
        }
    }

    private void CharActive()//�Ѿ��
    {
        //������ �����ִ� ������Ʈ ��Ȱ��ȭ�ϱ�
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].activeSelf)
            {
                characters[i].SetActive(false);
                break;
            }
        }

        //�ε��� �ȿ� �ִ� ������Ʈ Ȱ��ȭ�ϱ�
        characters[index].SetActive(true);
    }

    private void Selected()//���� �����ϱ�
    {
        //���� Ȱ��ȭ�Ǿ� �ִ� ĳ���� �ε��� PlayerPrefs ����
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].activeSelf)
            {
                PlayerPrefs.SetInt("Info", i);
                break;
            }
        }

        //���� ������ �ѱ��
        SceneManager.LoadScene(1);
    }


}
