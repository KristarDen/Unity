using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate2 : MonoBehaviour
{
    public static bool isOpen = false;
    void Start()
    {

    }


    void Update()
    {
        if (isOpen == true)
        {
            transform.Rotate(0, 10.0f * Time.deltaTime, 0);
        }
    }
}
