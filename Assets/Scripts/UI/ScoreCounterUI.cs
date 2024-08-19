using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += UpdateScore;
        UpdateScore(0);
    }
    
    private void OnDestroy()
    {
        ScoreManager.Instance.OnScoreChanged -= UpdateScore;
    }


    private void UpdateScore(int score)
    {
        _text.text = "SCORE: " + score.ToString();
    }

}
