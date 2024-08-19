using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    
    public static ScoreManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    public Action<int> OnScoreChanged;

    public int Score { get; private set; } = 0;


    private void Start()
    {
        GameManager.Instance.OnStateChange += OnGameStateChange;
    }
    
    private void OnDestroy()
    {
        GameManager.Instance.OnStateChange -= OnGameStateChange;
    }

    private void OnGameStateChange(GameState newState)
    {
        if(newState == GameState.GameOver)
        {
            ResetScore();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        OnScoreChanged?.Invoke(Score);
    }
    
    public void ResetScore()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score);
    }
    
}
