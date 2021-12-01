using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainScreen;
    public Slider speedSlider;
    bool isGameStarted = false;
    float gameSpeed = 1;
    void Start()
    {
        mainScreen = GameObject.Find("MainScreen");
        speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>(); 
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartOrContinue();
        }
    }

    public void StartOrContinue()
    {
        if (isGameStarted == false)
        {
            Time.timeScale = gameSpeed;
            isGameStarted = true;
            this.gameObject.SetActive(false);
            
        }
        else
        {
            Time.timeScale = gameSpeed;
            mainScreen.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }

    public void GameSpeed()
    {
        gameSpeed = speedSlider.value;
        Debug.Log(gameSpeed.ToString());
    }

    public void Quit()
    {
        Application.Quit();
    }
}
