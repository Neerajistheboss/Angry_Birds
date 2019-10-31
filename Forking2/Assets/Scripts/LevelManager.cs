using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public float timeToLoadNextLevel;
   

    

    // Start is called before the first frame update
    void Start()
    {
        Button.selectedDefender = null;
        if(timeToLoadNextLevel>0)
        Invoke("loadNextLevel",timeToLoadNextLevel);
    }


    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void startGame()
    {
        SceneManager.LoadScene("level 01");
    }


    public void loadNextLevel()
    {
        
        SceneManager.LoadScene(Application.loadedLevel+1); 
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   // public void PlayAgain()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   // }

    public void optionsScene()
    {
        SceneManager.LoadScene("Options");
    }

}
