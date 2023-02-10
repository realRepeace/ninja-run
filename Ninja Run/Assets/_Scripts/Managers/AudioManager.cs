using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour       //regelt die Eigenschaften und das Abspielen von Sounds im Spiel
{
    public Sound[] sounds;

    private void Awake() //Für Jeden Sound wird eine Audioquelle erstellt am Anfang und Einstellungsmöglichkeiten für den Inspektor hinzugefügt
    {

        foreach (Sound s in sounds)   
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if (s.RandomPitch == true)
        {
            s.source.pitch = UnityEngine.Random.Range(s.MinPitch, s.MaxPitch);  //zufällige Tonhöhe Einstellbalken im Editor
        }
        s.source.PlayOneShot(s.clip);
    }
}
