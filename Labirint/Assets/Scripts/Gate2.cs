using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate2 : MonoBehaviour
{
    public static bool isOpen = false;
    public static bool isSlowOpen = false;
    void Start()
    {

    }


    void Update()
    {
        if (isOpen == true)
        {
            transform.Rotate(0, 12.0f * Time.deltaTime, 0);
        }
        else if (isSlowOpen == true)
        {
            transform.Rotate(0, 1.0f * Time.deltaTime, 0);
        }
    }
}
