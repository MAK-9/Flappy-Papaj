using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource jaskier;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip deathBell;

    public AudioClip[] jpSounds;
    int audioIndex;

    void Start()
    {
        jaskier = GetComponent<AudioSource>();

    }

    public void grajDeath()
    {
        jaskier.PlayOneShot(death);
    }

    public void grajJump()
    {
        jaskier.PlayOneShot(jump);
    }
    public void grajDeathBell()
    {
        jaskier.PlayOneShot(deathBell);
    }
    public void grajRandom()
    {
        //jaskier.PlayOneShot(jeszczeJak);
        audioIndex = Random.Range(0, jpSounds.Length);
        jaskier.PlayOneShot(jpSounds[audioIndex]);
    }

}
