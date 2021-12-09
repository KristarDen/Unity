using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private bool isStarted = false;
    public static bool isGameStarted = false;
    public static GameObject Menu;
    public Button StartButton;

    void Start()
    {
        Menu = GameObject.Find("Menu");
        Time.timeScale = 0f;

        StartButton = GameObject.Find("StartButton").GetComponent<Button>();

        StartButton.onClick.AddListener(delegate { StartOrContinue(); });
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

    static public void StartOrContinue()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
