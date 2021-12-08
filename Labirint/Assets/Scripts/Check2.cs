using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check2 : MonoBehaviour
{

    public Image circle;
    public Text countdown;

    public float timeToOver = 10f;
    private float tick;

    bool isSlowOpen = false;

    void Start()
    {
        circle = GameObject.Find("Timer2").GetComponent<Image>();
        countdown = GameObject.Find("Countdown2").GetComponent<Text>();
        countdown.text = $"{timeToOver}";
        
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
        if (other.name == "Ball")
        {
            Touch();
        }
    }

    public void Touch()
    {
        if (isSlowOpen == true) Gate2.isSlowOpen = true;
        else Gate2.isOpen = true;
        CancelInvoke("TimerCountdown");
        UICheckTimer.Hide();
        this.gameObject.SetActive(false);
    }
    public void StartTimer()
    {
        InvokeRepeating("TimerCountdown", 1.0f, 1.0f);
        UICheckTimer.Show();
    }

}
