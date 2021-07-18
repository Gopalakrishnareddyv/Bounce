using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastSCore : MonoBehaviour
{
    public Text text;
    
    private void Start()
    {
        
    }
    private void Update()
    {
        text.text = Score.lastTextScore;
    }
}
