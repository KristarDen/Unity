using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;

    public float ForceMagnitude = 5000;

    public float ForceMagnitude2 = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * ForceMagnitude2 * Time.deltaTime);
        }
    }
}
