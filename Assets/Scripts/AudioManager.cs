using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource springSource = default;

    public void SpringSound()
    {
        springSource.Play();
    }
}
