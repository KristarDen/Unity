using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerScript : MonoBehaviour
{
    public Slider Hunger;
    void Start()
    {
        Hunger = GameObject.Find("Hunger").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Hunger.value -= (1f * Time.deltaTime);
    }
}
