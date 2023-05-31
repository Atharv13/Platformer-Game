using UnityEngine.Audio;
using UnityEngine;
using System;

public class soundmanager : MonoBehaviour
{

    public sound[] sounds;
    public static soundmanager instance;
   

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach (sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }
    
    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
