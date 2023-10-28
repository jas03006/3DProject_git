using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider, brightSlider; // �����̴� UI ���
    public AudioSource audioSource; // ����� �ҽ�

    private void Start()
    {
        //�ʱ� ���� ����
       // volumeSlider.value = audioSource.volume;

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
