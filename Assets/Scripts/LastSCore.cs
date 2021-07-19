using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LastSCore : MonoBehaviour
{
    public Text text;
    public Text HighText;
    public static int  highscore;
    private void Start()
    {
        
    }
    private void Update()
    {
        text.text ="Score : "+ Score.lastTextScore.ToString();
        if (Score.lastTextScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",Score.lastTextScore);
            highscore = Score.lastTextScore;
        }
        HighText.text ="High Score :"+PlayerPrefs.GetInt("HighScore").ToString();
    }
}
