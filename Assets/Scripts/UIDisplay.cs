using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{ 
    [SerializeField] Health playerHealth;
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI displayScore;
    [SerializeField] Slider healthBar;
    void Start()
    {
        healthBar.maxValue = playerHealth.GetHealth();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update() 
    {
        healthBar.value = playerHealth.GetHealth();
        displayScore.SetText(scoreKeeper.GetCurrentScore().ToString("000000000"));
    }
}
