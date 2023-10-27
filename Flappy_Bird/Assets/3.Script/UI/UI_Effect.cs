using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Effect : MonoBehaviour
{
    [SerializeField] private GameObject endMenu, pauseMenu;

    private void Start()
    {
        endMenu = GetComponent<GameObject>();
        pauseMenu = GetComponent<GameObject>();
    }

    public void OnClickButton()
    {
        if (endMenu.activeSelf)
        {
            Debug.Log("Test");
        }
        else
        {

        }
    }

}
