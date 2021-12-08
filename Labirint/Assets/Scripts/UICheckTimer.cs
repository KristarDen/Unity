using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICheckTimer : MonoBehaviour
{
    static public Text CountdownUI = GameObject.Find("CountdownUI").GetComponent<Text>(); // Text with number of time
    static public Image TimerUI = GameObject.Find("TimerUI").GetComponent<Image>(); // Circle 



    static void Start()
    {
        CountdownUI.gameObject.SetActive(false);
        TimerUI.gameObject.SetActive(false);
    }


    void Update()
    {

    }

    static public void ChangeState(string text, float timerfill)
    {
        CountdownUI.text = text;
        TimerUI.fillAmount -= timerfill;
    }

    static public void Hide()
    {
        CountdownUI.gameObject.SetActive(false);
        TimerUI.gameObject.SetActive(false);
    }

    static public void Show()
    {
        CountdownUI.gameObject.SetActive(true);
        TimerUI.gameObject.SetActive(true);
    }
}
