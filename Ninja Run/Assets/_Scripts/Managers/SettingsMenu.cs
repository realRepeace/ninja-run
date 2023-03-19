using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour       //regelt den Sound im Einstellungsmenü
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("currentVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("currentVolume");
            volumeSlider.value = savedVolume;
        }
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("currentVolume", volume);
    }

}
