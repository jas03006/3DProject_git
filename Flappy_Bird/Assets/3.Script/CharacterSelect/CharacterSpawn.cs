using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    #region ĳ���� ����
    /*
     <ĳ���� ���� �����>
     */
    #endregion
    [Header("ĳ���� ����")]
    [SerializeField] private GameObject[] characters; //ĳ���� ������Ʈ �迭
    [SerializeField] private Transform spawnPosition;
      
    private void Awake()
    {
        spawnPosition = GetComponent<Transform>();
    }
    void Start()
    {
        Instantiate(characters[PlayerPrefs.GetInt("Info")], spawnPosition.position, Quaternion.identity);
        PlayerPrefs.DeleteKey("Info");
    }
}
