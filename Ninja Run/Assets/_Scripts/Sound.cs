using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound      //Um Sound in Inspektor zu ändern
{

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(1f, 3f)]
    public float pitch;

    public bool loop;

    public bool RandomPitch;

    [Range(0.5f, 1.5f)]
    public float MinPitch;

    [Range(0.5f, 1.5f)]
    public float MaxPitch;



    [HideInInspector]
    public AudioSource source;
}
