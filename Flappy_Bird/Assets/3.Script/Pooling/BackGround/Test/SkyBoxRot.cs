using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRot : MonoBehaviour //�ϴ� �����̴°�, �̰� �� ���ӸŴ����� �ھƵ� �ɵ�???
{
    private float SkySpeed = 0f;
    [SerializeField] private float SkyBoxSpeed = 0f;

    private float evening;
    private void Update()
    {
        SkySpeedMove();
    }





    private void SkySpeedMove()
    {
        SkySpeed += Time.deltaTime* SkyBoxSpeed;
        if (SkySpeed >= 360)
        {
            SkySpeed = 0f;
        }
        RenderSettings.skybox.SetFloat("_Rotation", SkySpeed);
    }
}
