using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jupiter : MonoBehaviour
{
    public Transform rotateObj;
    public Transform aroundObj;
    public float rotSpeed = 20f;
    public float selfrotSpeed = 20f;

    void Start()
    {
        rotateObj = this.transform.gameObject.GetComponent<Transform>();
        aroundObj = GameObject.Find("Sun").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateObj.RotateAround(aroundObj.position, new Vector3(0, 1, 0), rotSpeed * Time.deltaTime);


        transform.Rotate(0, selfrotSpeed * Time.deltaTime, 0);

    }
}
