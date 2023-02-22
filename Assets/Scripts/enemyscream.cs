using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
//clara
public class enemyscream : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] clips;

    //vad som spelar(ljud)
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
    }

    // tar bort gameobject
    private void Update()
    {
        if (audioSource.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }

}
