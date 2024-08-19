using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameplayScreen;
    [SerializeField] private GameObject _failScreen;

    private void Start()
    {
        _mainMenu.SetActive(true);
        _pauseMenu.SetActive(false);
        _gameplayScreen.SetActive(false);
        _failScreen.SetActive(false);
        
        GameManager.Instance.OnStateChange += ShowScreen;
    }
    
    private void OnDestroy()
    {
        GameManager.Instance.OnStateChange -= ShowScreen;
    }

    private void ShowScreen(GameState state)
    {
        _mainMenu.SetActive(state == GameState.MainMenu);
        _pauseMenu.SetActive(state == GameState.Pause);
        _gameplayScreen.SetActive(state == GameState.InGame);
        _failScreen.SetActive(state == GameState.GameOver);
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void Restart()
    {
        GameManager.Instance.Restart();
    }
    
    public void Pause()
    {
        GameManager.Instance.Pause();
    }
    
}
