using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Plays Spring Sound when landing on Platform
    /// </summary>
    [SerializeField]
    private AudioSource springSource = default;

    public void SpringSound()
    {
        springSource.Play();
    }
}
