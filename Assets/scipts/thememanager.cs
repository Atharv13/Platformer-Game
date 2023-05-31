using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thememanager : MonoBehaviour {

    public AudioSource bgm;
	void Start () {
		
	}
    public void changebgm(AudioClip audio)
    {
        bgm.Stop();
        bgm.clip = audio;
        bgm.Play();
    }
}
