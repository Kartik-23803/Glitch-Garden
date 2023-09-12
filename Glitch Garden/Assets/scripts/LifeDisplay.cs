using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 10;
    [SerializeField] int damage = 1;
    [SerializeField] GameObject loseLabel;
    float lives;
    TMP_Text livesText;
    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        loseLabel.SetActive(false);
        livesText = GetComponent<TMP_Text>();
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLives()
    {
        lives -= damage;
        UpdatePoints();
        if(lives<=0)
        {
            StartCoroutine(HandleLoseCondition());
        }
    }

    IEnumerator HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSeconds(10);
        FindObjectOfType<LevelLoad>().LoadGameOver();
    }
}
