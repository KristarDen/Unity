using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicON : MonoBehaviour
{
    public Toggle MusicToogle;
    public Text Label;
    void Start()
    {
        MusicToogle = GameObject.Find("MusicOnToogle").GetComponent<Toggle>();
        Label = GameObject.Find("MusicOnToogle").GetComponent<Text>();
        MusicToogle.onValueChanged.AddListener(value => HandleOnValueChanged(value));
    }


    void Update()
    {
        
    }

    void HandleOnValueChanged(bool value)
    {
        if (MusicToogle.isOn) Label.text = "On";
        else Label.text = "Off";
    }
}
