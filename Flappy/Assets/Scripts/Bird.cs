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

    private uint score = 0;

    bool triggerTouch = false; //false you touched first line of trigger true second 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Text = GameObject.Find("Text").GetComponent<Text>();
        Text.text = $"{score}";
    }

    private bool gameIsEnd = false;

    void Update()
    {
        if (gameIsEnd == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * ForceMagnitude2 * Time.deltaTime);
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
            Text.text = $"Game over \nScore: {score}";
            Destroy(GameObject.Find("MainScreen"));
            Destroy(this.gameObject);
        }
        
    }
}
