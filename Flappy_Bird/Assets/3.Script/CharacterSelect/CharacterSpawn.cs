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
    [SerializeField] private GameObject[] chars; //ĳ���� ������Ʈ �迭
    [SerializeField] private Transform spawnPos;
      
    private void Awake()
    {
        spawnPos = GetComponent<Transform>();
        Instantiate(chars[PlayerPrefs.GetInt("Info")], spawnPos.position, Quaternion.identity);
        PlayerPrefs.DeleteKey("Info");
    }
}
