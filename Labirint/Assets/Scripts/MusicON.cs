using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicON : MonoBehaviour
{
    public Toggle MusicToogle;
    public GameObject UI;
    private AudioSource Music;
    public Text Label;
    void Start()
    {
        MusicToogle = GameObject.Find("MusicOnToggle").GetComponent<Toggle>();
        Label = GameObject.Find("MusicToggleLabel").GetComponent<Text>();
        Music = GameObject.Find("UI").GetComponent<AudioSource>();
        MusicToogle.onValueChanged.AddListener((value) => {
            if (MusicToogle.isOn)
            {
                Label.text = "On";
                Music.Play();
                MusicToogle.Select();
            }
            else
            {
                Music.Pause();
                Label.text = "Off";
            }
        });
        
    }


    void Update()
    {
        
    }

    void HandleOnValueChanged(bool value)
    {
        
    }
}
