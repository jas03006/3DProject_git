using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRot : MonoBehaviour //�ϴ� �����̴°�, �̰� �� ���ӸŴ����� �ھƵ� �ɵ�???
{
    [SerializeField] private float SkySpeed = 0f;
    private void Update()
    {
        SkySpeedMove();
    }
    private void SkySpeedMove()
    {
        SkySpeed += Time.deltaTime*2;
        if (SkySpeed >= 360)
        {
            SkySpeed = 0f;
        }
        RenderSettings.skybox.SetFloat("_Rotation", SkySpeed);
    }
}
