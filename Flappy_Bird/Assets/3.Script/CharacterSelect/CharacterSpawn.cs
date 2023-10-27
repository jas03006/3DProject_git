using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    #region 캐릭터 스폰
    /*
     <캐릭터 스폰 실험용>
     */
    #endregion
    [Header("캐릭터 스폰")]
    [SerializeField] private GameObject[] chars; //캐릭터 오브젝트 배열
    [SerializeField] private Transform spawnPos;
      
    private void Awake()
    {
        spawnPos = GetComponent<Transform>();
        Instantiate(chars[PlayerPrefs.GetInt("Info")], spawnPos.position, Quaternion.identity);
        PlayerPrefs.DeleteKey("Info");
    }
}
