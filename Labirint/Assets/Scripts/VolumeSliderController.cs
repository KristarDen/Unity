using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    public Slider VolumeSlider;
    public Text VolumeLabel;
    private AudioSource Soundtrack;
    void Start()
    {
        VolumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        VolumeSlider.onValueChanged.AddListener(delegate { SliderChanged(); });
        VolumeLabel = GameObject.Find("VolumeValue").GetComponent<Text>();
        Soundtrack =  GameObject.Find("UI").GetComponents<AudioSource>()[0];
        SliderChanged();
    }

    
    void Update()
    {
        
    }

    void SliderChanged()
    {
       VolumeLabel.text = $"{ (int)((VolumeSlider.value * 100) % 100)}%";
       BallController.volume = VolumeSlider.value;
       Soundtrack.volume = VolumeSlider.value;
    }


}
