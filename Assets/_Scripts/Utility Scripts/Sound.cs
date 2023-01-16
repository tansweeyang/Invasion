using UnityEngine.Audio;
using UnityEngine;

//To show custom class without mono behavior in the editor
[System.Serializable]
public class Sound
{
    //-------------------------------------Class Variables--------------------------------------
    public string name;
    
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;

    public AudioMixerGroup mixer;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
    //------------------------------------------------------------------------------------------
}
