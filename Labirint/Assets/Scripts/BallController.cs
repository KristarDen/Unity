using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ForceFactor = 100;
    private Vector3 forceDirection;
    Rigidbody rb;
    void Start()
    {
        forceDirection = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        forceDirection.x = Input.GetAxis("Horizontal");
        forceDirection.z = Input.GetAxis("Vertical");

        rb.AddForce(forceDirection * ForceFactor * Time.deltaTime);
    }
}
