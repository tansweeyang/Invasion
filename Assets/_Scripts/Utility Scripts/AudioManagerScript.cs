using UnityEngine.Audio;
using UnityEngine;
using System;

//Collections of sounds
//Able to set sound settings
public class AudioManagerScript : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public Sound[] sounds;
    public static AudioManagerScript instance;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Audio Methods----------------------------------------
    //Setup
    void Awake()
    {
        //Singleton AudioManager
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //Don't destroy AudioManager
        DontDestroyOnLoad(gameObject.transform.parent.gameObject);

        //Create a gameObject for each audio source
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if(s == null)
        {
            Debug.Log("Audio clip " + name + " is not found");
            return;
        }
        else
        {
            s.source.Play();
        }
    }

    public void Stop(String name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if (s == null)
        {
            Debug.Log("Audio clip " + name + " is not found");
            return;
        }
        else
        {
            s.source.Stop();
        }
    }
    //------------------------------------------------------------------------------------------
}
