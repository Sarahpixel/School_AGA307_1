using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Title, Playing, Paused, GameOver, }
public enum Difficulty { Easy, Medium, Hard, }

public class GameManager : Singleton<GameManager>
{
    public static event Action<Difficulty> OnDifficultyChanged = null; // event

    public float health;
    public GameState gameState;
    public Difficulty difficulty;
    public int score;
    int scoreMultiplyer =1;
    float timer;
  
    private void Start()
    {
        timer = 0;
        Setup();
        OnDifficultyChanged?.Invoke(difficulty);
    }
    //private void Awake() // singleton pattern that can be accessed by all the other scripts 
    //{
    //    if (instance == null) // if the game manager doesn't exist create the script
    //        instance = this;
    //    else
    //        Destroy(this); // we're only allowed to have one copy of the gamemanager
    //}
    private void Update()
    {
        
        if (gameState == GameState.Playing)
        {
            timer += Time.deltaTime;
            _UI.UpdateTimer(timer);
        }
        
    }
    public void AddScore(int _score)
    {
        score += _score*scoreMultiplyer;
        _UI.UpdateScore(_score);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void LoidTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChangeDifficulty(int _difficulty) //based on the int value
    {
        difficulty = (Difficulty)_difficulty;
        Setup();
    }
    private void OnEnable()
    {
        Enemy.OnEnemyHit += OnEnemyHit;
        Enemy.OnEnemyDie += OnEnemyDie;
    }
    private void OnDisable()
    {
        Enemy.OnEnemyHit -= OnEnemyHit; // only does this function once
        Enemy.OnEnemyDie -= OnEnemyDie; // only does this function once
    }
    void OnEnemyHit(GameObject _enemy)
    {
        AddScore(10);
    }
    void OnEnemyDie(GameObject _enemy)
    {
        AddScore(100);
    }
    void Setup()
    {
        switch (difficulty)
        {

            case Difficulty.Easy:
                scoreMultiplyer = 1;
                break;

            case Difficulty.Medium:
                scoreMultiplyer = 2;
                break;
            case Difficulty.Hard:
                scoreMultiplyer = 3;
                break;
        }
    }
}