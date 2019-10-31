using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;
    private musicManager musicMange;


    // Start is called before the first frame update
    void Start()
    {
        musicMange = GameObject.FindObjectOfType<musicManager>();
        volumeSlider.value = PlayerPrefsManager.getMasterVolume();
        difficultySlider.value = PlayerPrefsManager.getDifficulty();

    }

    // Update is called once per frame
    void Update()
    {
        musicMange.changeVolume(volumeSlider.value);
        
    }


    public void saveAndExit()
    {
        PlayerPrefsManager.setMasterVolume(volumeSlider.value);
        PlayerPrefsManager.setDifficulty(difficultySlider.value);
        SceneManager.LoadScene("MainMenu");
    }

    public void defaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }
}
