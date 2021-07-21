using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [HideInInspector]
    public static bool SoundIsEnabled;
    private void Awake()
    {
        SoundIsEnabled = SaveSystem.LoadSoundIsEnabled();
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.name = sound.name;
            sound.source.volume = sound.volume;
            sound.source.clip = sound.clip;
          //  sound.source.enabled = SoundIsEnabled;
        }
    }
    [HideInInspector]
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, Sound => Sound.name == name);
        if(sound == null)
        {
            Debug.Log($"There is no sound with {name} name");
        }
        else
        {
            if (SoundIsEnabled)
                sound.source.Play();
        }
    }
    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, Sound => Sound.name == name);
        if (sound == null)
        {
            Debug.Log($"There is no sound with {name} name");
        }
        else
        {
            if (SoundIsEnabled && sound.source.isPlaying)
                sound.source.Stop();
        }
    }
}
