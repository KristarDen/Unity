using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerScript : MonoBehaviour
{
    public Slider Hunger;
    GameObject Bird;
    Text Label;

    void Start()
    {
        Hunger = GameObject.Find("Hunger").GetComponent<Slider>();
        Bird = GameObject.Find("Bird");
        Label = GameObject.Find("HungerLabel").GetComponent<Text>();

        Hunger.value = 100;
        Label.text = $"Hunger {(int)Hunger.value}";
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hunger.value - 1f * Time.deltaTime > 1f)
        {
            Hunger.value -= (1f * Time.deltaTime);
            Label.text = $"Hunger {(int)Hunger.value}";
        }
        else
        {
            Bird.GetComponent<Bird>().GameOver();
        }
    }
}
