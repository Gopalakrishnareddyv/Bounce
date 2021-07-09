using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public int score = 0;
    public void Increment()
    {
        score++;
        text.text = "Score : " + score;
    }
    
}
