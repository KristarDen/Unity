using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private float time;
    private Text clock;

    void Start()
    {
        time = 0;
        clock = GameObject.Find("Clock").GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
    }

    private void LateUpdate()
    {
        int t = (int)time;
        int h = t / 3600;
        int m = (t % 3600) / 60;
        int s = (t % 60);
        int d = (int)((time - t) * 10);
        clock.text = (h < 10 ? "0" : "") + h + ":"
            + (m < 10 ? "0" : "") + m + ":"
            + (s < 10 ? "0" : "") + s + "." + d;
    }
}

