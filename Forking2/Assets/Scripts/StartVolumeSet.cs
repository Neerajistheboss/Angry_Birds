using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVolumeSet : MonoBehaviour
{
    private musicManager mm;
    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindObjectOfType<musicManager>();
        if (mm)
        {
            float volume = PlayerPrefsManager.getMasterVolume();
            mm.changeVolume(volume);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
