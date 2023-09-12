using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 3f;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Master volume set to "+ volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float diff)
    {
        if(diff >= MIN_DIFFICULTY && diff <= MAX_DIFFICULTY)
        {
            Debug.Log("Difficulty level is set to "+ diff);
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }
        else
        {
            Debug.LogError("Difficulty is out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}