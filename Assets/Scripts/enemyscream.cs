using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class enemyscream : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] clips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
    }

    private void Update()
    {
        if (audioSource.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }

}
