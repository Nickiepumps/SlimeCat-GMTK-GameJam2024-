using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public AudioClip walkClip;
    public AudioClip jumpClip;
    public AudioClip dieClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkSound()
    {
        audioSource.clip = walkClip;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpClip);
    }

    public void PlayDieSound()
    {
        audioSource.PlayOneShot(dieClip);
    }

    public void StopWalkSound()
    {
        if (audioSource.clip == walkClip && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}