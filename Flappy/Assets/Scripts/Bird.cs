using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;

    public float ForceMagnitude = 5000;

    public float ForceMagnitude2 = 100;

    private Text Score;
    private Text Clock;

    private GameObject Menu;
    private GameObject mainScreen;

    GameObject Pixel_Egg;
    GameObject Bug;

    private GameObject healthBar;

    private uint score = 0;

    private int health = 3;

    bool triggerTouch = false; //false you touched first line of trigger true second 
    bool itemTouch = false;

    public Slider Hunger;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Score = GameObject.Find("Score").GetComponent<Text>();
        Clock = GameObject.Find("Clock").GetComponent<Text>();
        Menu = GameObject.Find("Menu");
        mainScreen = GameObject.Find("MainScreen");

        healthBar = GameObject.Find("HealthBar");

        Hunger = GameObject.Find("Hunger").GetComponent<Slider>();

        Pixel_Egg = GameObject.Find("Egg-Pixel");
        Bug = GameObject.Find("Bug");

        Score.text = $"{score}";
    }

    bool gameIsEnd = false;
    float direction = 1f;
    float angle;

    void Update()
    {
        if (gameIsEnd == false)
        {
            angle = transform.eulerAngles.z;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * ForceMagnitude2 * Time.deltaTime);
                angle += 30f;
            }

            
            if (angle > 180f) angle -= 360f;

            if ((angle < -55f) || (angle > 55f)) direction *= -1f;

            transform.Rotate(0, 0, rb.velocity.y * 10f * direction * Time.deltaTime);

            if (Input.GetKey(KeyCode.Escape))
            {
                if(Menu.active == false)
                {
                    Menu.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
      {

        if (collision.gameObject.name == "Trigger")
        {
            if (triggerTouch == false)
            {
                score += 1;
                Score.text = $"{score}";
                triggerTouch = true;
            }
            else
            {
                triggerTouch = false;
            }

        }
        else if (collision.gameObject.name == "Bug")
        {

            if (Hunger.value + 30f > 100f)
            {
                Hunger.value += 100f - Hunger.value;
            }
            Hunger.value += 30f;

            collision.gameObject.SetActive(false);


        }
        else if (collision.gameObject.name == "Egg-Pixel")
        {
            if(itemTouch == false)
            {
                if (health < 3)
                {
                    health++;
                    healthBar.transform.GetChild((health - 1)).gameObject.SetActive(true);
                    Debug.Log("Health : " + health);
                }
                collision.gameObject.SetActive(false);
                itemTouch = true;
            }
            else
            {
                itemTouch = false;
            }
            
        }
        else if (collision.gameObject.name == "Spawn")
        {

        }
        else if (collision.gameObject.transform.parent.transform.parent.gameObject.tag == "Tube")
        {
            if (health >= 1)
            {
                Debug.Log("???????????? ? " + collision.gameObject.transform.parent.transform.parent.gameObject.name);

                // teleport to safe point (tube center)
                this.transform.position = new Vector2(
                collision.gameObject.transform.parent.transform.parent.gameObject.transform.position.x + 0.6f,
                collision.gameObject.transform.parent.transform.parent.gameObject.transform.position.y - 0.5f);


                rb.gravityScale = 0.1f;
                InvokeRepeating("GravityPause", 2.0f, 0.25f);


                healthBar.transform.GetChild((health - 1)).gameObject.SetActive(false);
                health--;


            }
            else
            {
                GameOver();
            }

        }
        

        else
        {

            GameOver();
        }
        
    }

    public void GameOver()
    {
        Menu.GetComponent<GameControl>().setRecord();
        
        Destroy(healthBar);
        Destroy(GameObject.Find("MainScreen"));
        Destroy(Pixel_Egg);
        Destroy(Bug);
        GameObject.Find("Clock").GetComponent<Text>().enabled = false;
        Score.text = $"Game over \nScore: {score} \nTime: {Clock.text}\nPress enter to restart";
        Hunger.gameObject.SetActive(false);
        
        Destroy(this.gameObject);
    }

    private void GravityPause()
    {
        if(rb.gravityScale < 0.3f)
        {
            rb.gravityScale += 0.05f;
        }
        else
        {
            CancelInvoke("GravityPause");
        }
        Debug.Log("Bird gravity scale: " + rb.gravityScale);
    }
}
