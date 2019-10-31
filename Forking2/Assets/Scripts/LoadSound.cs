using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSound : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        float volume = PlayerPrefsManager.getMasterVolume();
        audioSource.volume = volume;
    }

    // Update is called once per frame
    
}
