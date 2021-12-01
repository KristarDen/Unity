using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;

    public float ForceMagnitude = 5000;

    public float ForceMagnitude2 = 100;

    private Text Text;
    private Text Clock;

    private GameObject Menu;
    private GameObject mainScreen;

    private uint score = 0;

    bool triggerTouch = false; //false you touched first line of trigger true second 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Text = GameObject.Find("Text").GetComponent<Text>();
        Clock = GameObject.Find("Clock").GetComponent<Text>();
        Menu = GameObject.Find("Menu");
        mainScreen = GameObject.Find("MainScreen");
        
        Text.text = $"{score}";
    }

    public bool gameIsEnd = false;

    void Update()
    {
        if (gameIsEnd == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * ForceMagnitude2 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                if(Menu.active == false)
                {
                    Menu.SetActive(true);
                    Time.timeScale = 0;
                    mainScreen.SetActive(false);
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
     {

        if( collision.gameObject.name == "Trigger")
        {
            if(triggerTouch == false)
            {
                score += 1;
                Text.text = $"{score}";
                triggerTouch = true;
            }
            else
            {
                triggerTouch = false;
            }
            
        }
        else
        {
            Text.text = $"Game over \nScore: {score} \nTime: {Clock.text}\nPress enter to restart";
            Destroy(GameObject.Find("MainScreen"));
            GameObject.Find("Clock").GetComponent<Text>().enabled = false;
            Destroy(this.gameObject);

        }
        
    }
}
