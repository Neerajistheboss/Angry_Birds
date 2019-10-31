using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameTimer : MonoBehaviour
{
    GameObject looseCollider;
    
    private Text levelIndicator;
    private GameObject winLabel;
    //public AudioClip winMusic;
    Slider slider;
    public int levelSeconds;
    private AudioSource audioSource;
    bool timesUp;
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        looseCollider = GameObject.Find("LooseCollider");
        looseCollider.SetActive(true);
        
        Debug.Log("Started");
        levelIndicator = GameObject.Find("LevelIndicator").GetComponent<Text>();
        levelIndicator.text = SceneManager.GetActiveScene().name;
        Invoke("HideLevelIndicator",1f);
        winLabel = GameObject.Find("YouWin");
        winLabel.SetActive(false);
        audioSource = GetComponent <AudioSource>();
        slider = gameObject.GetComponent<Slider>();
        if (slider) Debug.Log("NoProblem");
        timesUp = false;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void HideLevelIndicator()
    {
        levelIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        if (slider.value == 1 && !timesUp)
        {
            looseCollider.SetActive(false);
            
            winLabel.SetActive(true);
            timesUp = true;
            
            audioSource.Play();

            Invoke("LoadNextLevel",audioSource.clip.length);

        }
    }

    void LoadNextLevel()
    {
        levelManager.loadNextLevel();
    }
}
