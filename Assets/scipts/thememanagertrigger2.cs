using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thememanagertrigger2 : MonoBehaviour
{

    public AudioClip tack2;
    public AudioClip tack1;
    private thememanager tm;
    private bool play_track1;
    void Start()
    {
        tm = FindObjectOfType<thememanager>();
        play_track1 = true;
    }

    private void Update()
    {
        if (thememanagertrigger.unlock)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (play_track1)
                {
                    tm.changebgm(tack2);
                    Debug.Log("cahnging track");
                    play_track1 = false;
                }
                else
                {
                    tm.changebgm(tack1);
                    Debug.Log("cahnging track");
                    play_track1 = true;
                }
            }
        }

    }

}


