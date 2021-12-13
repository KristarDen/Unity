using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera MainCamera;

    void Start()
    {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MainCamera.transform.RotateAround(
                this.transform.position,
                new Vector3(0, 0, 1),
                1);
            MainCamera.transform.RotateAround(
                this.transform.position,
                new Vector3(1, 0, 0),
                1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MainCamera.transform.RotateAround(
                this.transform.position,
                new Vector3(0, 0, 1),
                -1);
            MainCamera.transform.RotateAround(
               this.transform.position,
               new Vector3(1, 0, 0),
               -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MainCamera.transform.RotateAround(
                this.transform.position,
                Vector3.up,
                1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MainCamera.transform.RotateAround(
                this.transform.position,
                Vector3.up,
                -1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            MainCamera.fieldOfView = MainCamera.fieldOfView + 1f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            MainCamera.fieldOfView = MainCamera.fieldOfView - 1f;
        }
    }
}
