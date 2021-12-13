using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercuryRotate : MonoBehaviour
{
    public Transform rotateObj;
    public Transform aroundObj;
    public float rotSpeed = 10f;

    public float selfrotSpeed = 70f;

    void Start()
    {
        rotateObj = this.transform.gameObject.GetComponent<Transform>();
        aroundObj = GameObject.Find("Sun").GetComponent<Transform>();
    }


    void Update()
    {
        rotateObj.RotateAround(aroundObj.position, new Vector3(0, 1, 0), rotSpeed * Time.deltaTime);

        transform.Rotate(0, selfrotSpeed * Time.deltaTime, 0);
    }
}
