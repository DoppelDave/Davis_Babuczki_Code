using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource AudioSource;
    [SerializeField] private List<AudioClip> hitSounds = new List<AudioClip>();
    [SerializeField] private AudioClip deathSound;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void GetHit()
    {
        int rnd = Random.Range(0, hitSounds.Count);
        AudioSource.clip = hitSounds[rnd];
        AudioSource.Play();
    }

    public void Die()
    {
        AudioSource.clip = deathSound;
        AudioSource.Play();
    }
}
