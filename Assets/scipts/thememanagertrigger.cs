using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thememanagertrigger : MonoBehaviour {

    public AudioClip track2;
    public AudioClip track1;
    private thememanager thememanager;
    public static bool unlock;
    private bool playing_track1;
    private void Start()
    {
        thememanager = FindObjectOfType<thememanager>();
        playing_track1 = true;
    }

    
    private void Update()
    {
        if (unlock==true)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (playing_track1)
                {
                    thememanager.changebgm(track2);
                    Debug.Log("cahnging track");
                    playing_track1 = false;
                }
                else
                {
                    thememanager.changebgm(track1);
                    Debug.Log("cahnging track");
                    playing_track1 = true;
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            unlock = true;
            Debug.Log("unlocked");
        }
    }

}


