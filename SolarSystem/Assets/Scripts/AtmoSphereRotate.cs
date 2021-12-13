using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmoSphereRotate : MonoBehaviour
{
    public float selfrotSpeed = 150f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, selfrotSpeed * Time.deltaTime, 0);
    }
}
