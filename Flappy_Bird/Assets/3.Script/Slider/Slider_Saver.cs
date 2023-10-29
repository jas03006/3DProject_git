using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Saver : MonoBehaviour
{
    [SerializeField] Slider volume_slider;
    [SerializeField] Slider bright_slider;
    private void Start()
    {
        load();
    }
    public void save() {
        PlayerPrefs.SetFloat("volume", volume_slider.value);
        PlayerPrefs.SetFloat("brightness", bright_slider.value);
    }

    public void load()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            volume_slider.value = PlayerPrefs.GetFloat("volume");
        }
        else {
            volume_slider.value = 0.5f;
        }
        if (PlayerPrefs.HasKey("brightness"))
        {
            bright_slider.value = PlayerPrefs.GetFloat("brightness");
        }
        else {
            bright_slider.value = 0.5f;
        }
    }
}
