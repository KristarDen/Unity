using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    float MoveVelocity = 2;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * MoveVelocity * Time.deltaTime);
    }
}
