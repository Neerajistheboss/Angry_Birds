    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void changeVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
