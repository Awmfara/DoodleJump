using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip springClip;
    [SerializeField]
    private AudioSource springSource;

    public void SpringSound()
    {
        springSource.Play();
    }
}
