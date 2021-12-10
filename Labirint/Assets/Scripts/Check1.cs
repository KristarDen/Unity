using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check1 : MonoBehaviour
{
    public Image circle;
    public Text countdown;
    public GameObject Check2 ;

    public float timeToOver = 10f;
    private float tick;

    bool isSlowOpen = false;

    void Start()
    {
        Check2 = GameObject.Find("Check2");
        circle = GameObject.Find("Timer1").GetComponent<Image>();
        countdown = GameObject.Find("Countdown1").GetComponent<Text>();
        countdown.text = $"{timeToOver}";
        Check2.SetActive(false);
        InvokeRepeating("TimerCountdown", 1.0f, 1.0f);
        UICheckTimer.Show();
        tick = 1 / timeToOver;
    }

    void Update()
    {

    }
    void TimerCountdown()
    {
        if (timeToOver > 0)
        {
            timeToOver -= 1;
            circle.fillAmount -= tick;
            UICheckTimer.ChangeState($"{timeToOver}", tick);
            countdown.text = $"{timeToOver}";
        }
        else
        {
            isSlowOpen = true;
            UICheckTimer.Hide();
            CancelInvoke("TimerCountdown");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Ball")
        {
            Touch();
        }
    }

    public void Touch()
    {
        if (isSlowOpen == true) Gate1.isSlowOpen = true;
        else Gate1.isOpen = true;

        CancelInvoke("TimerCountdown");
        UICheckTimer.Hide();
        Check2.SetActive(true);
        Check2.GetComponent<Check2>().StartTimer();
        this.gameObject.SetActive(false);
    }
}
