using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTube : MonoBehaviour
{
    float MoveVelocity = 1;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector2.left * MoveVelocity * Time.deltaTime);
    }

    
}
