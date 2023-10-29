using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider audioSlider;


    public void AudioControl(float sliderVal)
    {
        float sound = audioSlider.value;
       /* if (sound == -40f)
        {
            mixer.SetFloat("BGMSetting", -80);
        }
        else
        {*/
            mixer.SetFloat("BGMSetting", sound*100f -80f);
        //}
    }
    public void ToggleAudiooVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

}
