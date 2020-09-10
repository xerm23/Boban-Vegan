using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    private float volume;
    private AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        volume = PlayerPrefs.GetFloat("Sound");
        audioSrc.volume = volume;
    }
}
