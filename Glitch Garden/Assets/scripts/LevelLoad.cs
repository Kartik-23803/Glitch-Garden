using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadOptions()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Options Screen");
    }
    public void LoadNextScene()
    {
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
