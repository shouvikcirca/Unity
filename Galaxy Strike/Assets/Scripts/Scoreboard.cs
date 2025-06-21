using System;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text scoreboardText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreboardText.text = score.ToString();
    }

}
