using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotate : MonoBehaviour
{
    public Transform rotateObj;
    public Transform aroundObj;
    public float rotSpeed = 100f;

    void Start()
    {
        rotateObj = this.transform.gameObject.GetComponent<Transform>();
        aroundObj = GameObject.Find("Earth").GetComponent<Transform>();
    }

    
    void Update()
    {
        rotateObj.RotateAround(aroundObj.position, new Vector3(0, 1, 0), rotSpeed * Time.deltaTime);
    }
}
