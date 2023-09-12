using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.6f;
    [SerializeField] Slider diffSlider;
    [SerializeField] float defaultDiff = 1f;
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        diffSlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music Player found...start splash screen");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(diffSlider.value);
        FindObjectOfType<LevelLoad>().LoadMainMenu();
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        diffSlider.value = defaultDiff;
    }
}
