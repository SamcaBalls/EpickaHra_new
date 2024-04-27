using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiencePlayer : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlaySound", 47f); // Invoke the method PlaySound after 47 seconds
    }

    void PlaySound()
    {

        audioSource.loop = true; // Set the audio to loop
        audioSource.clip = soundClip;
        audioSource.Play();
    }

}
