using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class RNDambianca : MonoBehaviour
{
    public AudioClip[] soundClips;
    private AudioSource audioSource;

    private bool canPlay = false;
    private float timeSinceLastPlay = 0f;
    private int ChanceModifier;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("EnablePlay", 10f); // Enable playing after 10 seconds
    }

    void Update()
    {
        if (canPlay)
        {
            timeSinceLastPlay += Time.deltaTime;
            if (timeSinceLastPlay >= 50f) // Play after every 50 seconds
            {
                if (Random.Range(0, 100000 - ChanceModifier) == 0) //chance time again
                {
                    PlayRandomSound();
                    timeSinceLastPlay = 0f;
                    ChanceModifier = 0;
                }
                ChanceModifier++;

            }
        }
    }

    void EnablePlay()
    {
        canPlay = true;
        if (Random.Range(0, 1000) == 0) //chance time 
        {
            PlayRandomSound();
        }
    }

    void PlayRandomSound()
    {
        if (soundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, soundClips.Length);
            audioSource.clip = soundClips[randomIndex];
            audioSource.Play();
        }
    }
}
