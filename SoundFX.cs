using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    // เสียงที่ต้องการใช้งาน
    public AudioClip walkClip;
    public AudioClip jumpClip;
    public AudioClip dieClip;

    // AudioSource สำหรับเล่นเสียง
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // โหลดคลิปเสียงล่วงหน้าเพื่อป้องกันการหน่วงเวลา
        audioSource.clip = walkClip;
    }

    public void PlayWalkSound()
    {
        if (audioSource.clip != walkClip)
        {
            audioSource.clip = walkClip;
        }
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlayJumpSound()
    {
        audioSource.clip = jumpClip;
        audioSource.PlayOneShot(jumpClip);
    }

    public void PlayDieSound()
    {
        audioSource.clip = dieClip;
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