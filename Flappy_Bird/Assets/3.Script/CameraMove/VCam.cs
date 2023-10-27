using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VCam : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        player = FindObjectOfType<CameraTestMovement>().transform;

        vCam.Follow = player;
        vCam.LookAt = player;
    }
}
