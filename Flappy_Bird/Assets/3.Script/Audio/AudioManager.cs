using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider, brightSlider; // 슬라이더 UI 요소
    public AudioSource audioSource; // 오디오 소스

    private void Start()
    {
        //초기 볼륨 설정
       // volumeSlider.value = audioSource.volume;

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
