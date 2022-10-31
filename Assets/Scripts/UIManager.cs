using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>   
{
    public TMP_Text scoreText;
    public TMP_Text difficultyText;
    public TMP_Text enemyCountText;
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int _score) //lil job for the ui manager
    {
        scoreText.text = "Score:" + _score;
    }
    public void UpdateEnemyCount(int _score)
    {
        scoreText.text = "EnemyCount:" + _score;
    }
    public void UpdateDifficulty(Difficulty difficulty)
    {
        difficultyText.text = difficulty.ToString();    
    }
    public void UpdateTimer(float _time)
    {
        timerText.text = _time.ToString("##:##");
    }
}
