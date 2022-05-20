using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour // attaced to canvas
{
    public static Score instance;
    int score;

    [SerializeField] int gemPoints=0;
    [SerializeField] int powerPoints;
    [SerializeField] TextMeshProUGUI scoreText;

   /* //.highscore
    [SerializeField] TextMeshProUGUI highScore;*/
    private void Start()
    {
        instance = this;     
    }
    public void ScoreUpdate()
    {
        if (!PauseMenu.playerDead)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void AddGempoints()
    {
        if (!PauseMenu.playerDead)
        {
            score = score + gemPoints;
            scoreText.text = score.ToString();
        }
    }

    public void ScoreOnPowerOn(int value)
    {

        if (!PauseMenu.playerDead && PowerUps.powerOn)
        {
            score = score +(value*powerPoints);
            scoreText.text = score.ToString();
        }
    }
}
