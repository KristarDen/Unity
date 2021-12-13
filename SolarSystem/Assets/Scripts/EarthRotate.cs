using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotate : MonoBehaviour
{
    public Transform rotateObj;
    public Transform aroundObj;
    public float rotSpeed = 100f;
    public float selfrotSpeed = 100f;

    void Start()
    {
        rotateObj = this.transform.gameObject.GetComponent<Transform>();
        aroundObj = GameObject.Find("Sun").GetComponent<Transform>();
    }

    void Update()
    {
        transform.Rotate(0, selfrotSpeed * Time.deltaTime, 0);


        rotateObj.RotateAround(aroundObj.position, new Vector3(0, 1, 0), rotSpeed * Time.deltaTime);
    }

}
