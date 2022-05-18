using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public  class Score : MonoBehaviour
{
    private static uint _score = 0;
    private static Text scoreUI = GameObject.Find("ScoreCount").GetComponent<Text>();
    void Start()
    {
        scoreUI = GameObject.Find("ScoreCount").GetComponent<Text>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void setScore(int score)
    {
        _score = (uint)score;
        scoreUI.text = "Score " + _score + "/ 10";
    }

    static public void plusScore()
    {
        _score++;
        scoreUI.text = "Score " + _score + "/ 10";
    }
}
