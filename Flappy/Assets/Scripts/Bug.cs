using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * 2 * Time.deltaTime);
    }
}
