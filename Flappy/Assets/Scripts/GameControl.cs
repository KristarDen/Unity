using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainScreen;
    public Slider speedSlider;
    bool isGameStarted = false;
    float gameSpeed = 1;
    public GameObject Hunger;
    public Text Score;

    Text BestTime;
    Text BestScore;

    Text Clock;

    public string saveFilePath = "records.txt";

    void Start()
    {
        mainScreen = GameObject.Find("MainScreen");
        speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();

        BestScore = GameObject.Find("BestTime").GetComponent<Text>();
        BestTime = GameObject.Find("BestScore").GetComponent<Text>();
        Score = GameObject.Find("Text").GetComponent<Text>();
        Time.timeScale = 0;
        Hunger = GameObject.Find("Hunger");

        Clock = GameObject.Find("Clock").GetComponent<Text>();
        getRecord();
    }

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
            Hunger.GetComponent<HungerScript>().enabled = true;
            this.gameObject.SetActive(false);
            getRecord();
        }
        else
        {
            Time.timeScale = gameSpeed;
            mainScreen.SetActive(true);
            Hunger.GetComponent<HungerScript>().enabled = true;
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

    void getRecord()
    {
        if (!File.Exists(saveFilePath))
        {
            BestScore.text = "0";
            BestTime.text = "00:00";
        }
        else
        {
            using (StreamReader sr = new StreamReader(saveFilePath))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if(i == 0)
                    {
                        BestScore.text = line;
                    }
                    else
                    {
                        BestTime.text = line;
                    }
                    i++;
                }
            }
        }
    }

    public void setRecord()
    {
        int currScore = Convert.ToInt32(Score.text.Trim());
        int bestScore = Convert.ToInt32(BestScore.text.Trim());

        using (StreamWriter sw = new StreamWriter(saveFilePath, false))
        {
            

            if (currScore > bestScore)
            {
                sw.WriteLine("" + currScore);
            }
            else
            {
                sw.WriteLine("" + bestScore);
            }

            if(string.Compare(Clock.text, BestTime.text) > 0)
            {
                sw.WriteLine(Clock.text.Trim());
            }
            else
            {
                sw.WriteLine(BestTime.text.Trim());
            }
        }
    }
}
