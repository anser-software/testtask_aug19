using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    
    public GameState State { get; private set; } = GameState.MainMenu;
    
    public Action<GameState> OnStateChange;
    


    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);

        ChangeState(GameState.MainMenu);
    }    
    
    private void ChangeState(GameState newState)
    {
        State = newState;
        OnStateChange?.Invoke(newState);
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
    }

    public void Restart()
    {
        SceneManager.UnloadSceneAsync(1).completed += (a) =>
        {
            StartGame();
        };
    }
    
    public void StartGame()
    {
        if(SceneManager.GetSceneByBuildIndex(1).isLoaded == false)
            SceneManager.LoadScene(1, LoadSceneMode.Additive);

        ChangeState(GameState.InGame);
    }

    public void Pause()
    {
        ChangeState(GameState.Pause);
    }
    
}

public enum GameState
{
    MainMenu,
    Pause,
    InGame,
    GameOver
}
