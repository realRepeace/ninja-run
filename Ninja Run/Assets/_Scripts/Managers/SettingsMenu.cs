using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour       //regelt den Sound im Einstellungsmenü
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public GameObject mutedSymbol;
    
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
        if (volumeSlider.value < 0.05f)
        {
            Mute();
        } else 
        {
            mutedSymbol.SetActive(false);
        }
        PlayerPrefs.SetFloat("currentVolume", volume);
    }

    public void Mute() 
    {
        volumeSlider.value = 0;
        mutedSymbol.SetActive(true);
        PlayerPrefs.SetFloat("currentVolume", volumeSlider.value);
    }

}
