using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float baseLevelTime = 10f;
    float levelTime;
    bool triggeredLevelFinished = false;
    float modifiedTime;

    void Start()
    {
        modifiedTime = 4 * PlayerPrefsController.GetDifficulty();
        levelTime = baseLevelTime + modifiedTime;
    }
    void Update()
    {
        if(triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
