using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text Text;

    float time = 0;
    string seconds = "0";
    string minuts = "0";

    void Start()
    {
        Text = GameObject.Find("Clock").GetComponent<Text>();
        Text.text = $"{time}";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (((int)time / 60) < 10) minuts = $"0{(int)time / 60}";
        else minuts = $"{(int)time / 60}";

        if (((int)time % 60) < 10) seconds = $"0{(int)time % 60}";
        else seconds = $"{(int)time % 60}";



        Text = GameObject.Find("Clock").GetComponent<Text>();
        Text.text = $"{minuts}:{seconds}";
    }
}
