using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    void Start()
    {
        ButtonCostLabel();
    }

    private void ButtonCostLabel()
    {
        TMP_Text costText = GetComponentInChildren<TMP_Text>();
        if(!costText)
        {
            Debug.LogError(name + " has no cost text");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41,41,41,255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}