using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
}
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    

}
