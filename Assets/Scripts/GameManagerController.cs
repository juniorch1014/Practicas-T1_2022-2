using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class GameManagerController : MonoBehaviour
{
    public TMP_Text scoreText;
 
    private int score;
 
    // Start is called before the first frame update
    void Start()
    {
        score = 5;
    }
    public int Score(){
        return score;
    }
  
    public void perderBala(int balas){
        score-=1;
        PrintScoreInScreen();
    }
    
    private void PrintScoreInScreen(){
        scoreText.text = "Balas: " + score;
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
