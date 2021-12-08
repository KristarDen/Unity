using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Image circle;
    public Text countdown;

    public float timeToOver = 20f;
    private float tick;
    void Start()
    {
        circle = GameObject.Find("Timer").GetComponent<Image>();
        countdown = GameObject.Find("Countdown").GetComponent<Text>();
        countdown.text = $"{timeToOver}";
        InvokeRepeating("TimerCountdown", 1.0f, 1.0f);
        tick = 1 / timeToOver;
    }

    void Update()
    {
        
    }
    void TimerCountdown()
    {
        if(timeToOver > 0)
        {
            timeToOver -= 1;
            circle.fillAmount -= tick;
            countdown.text = $"{timeToOver}";
        }
        else
        {
            CancelInvoke("TimerCountdown");
        }
         
    }
}
