using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void setMasterVolume(float volume)
    {
        if(volume>=0f&&volume<=1f)
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY,volume);
    }

    public static float getMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void unlockLevel(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY+level.ToString(),1);  //use 1 for true 
        }
    }

    public static bool isLevelUnlocked(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            if (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString())==1)
            {
                return true;
            }
            
           
        }

         return false;
    }

    public static void setDifficulty(float difficulty)
    {
        if (difficulty >=1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY,difficulty);
        }
    }

    public static float getDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }











}
