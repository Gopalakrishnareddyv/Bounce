using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public Text text;
    public int score = 0;
    
    public static int lastTextScore;
    public void Increment()
    {
        score++;
        text.text = "Score : " + score;
        lastTextScore =score;
        
    }
    
}
