using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLabel : MonoBehaviour
{
    private Text Text;
    private Slider speedSlider;

    void Start()
    {
        Text = GameObject.Find("SpeedLabel").GetComponent<Text>();
        speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
    }

    void Update()
    {
        
    }

    public void SliderChanged()
    {
        Text.text = $"Speed : x{speedSlider.value}";
    }
}
