using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float ForceFactor = 100;
    private Vector3 forceDirection;
    public Text Message;
    private Vector3 selfieRod;
    public Camera MainCamera;

    public Text Clock;


    public Rigidbody rb;
    void Start()
    {
        forceDirection = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        Message = GameObject.Find("Message").GetComponent<Text>();
        Clock = GameObject.Find("Clock").GetComponent<Text>();
        selfieRod = MainCamera.transform.position - this.transform.position;
    }

    void Update()
    {
        forceDirection.x = Input.GetAxis("Horizontal");
        forceDirection.z = Input.GetAxis("Vertical");

        rb.AddForce(forceDirection * ForceFactor * Time.deltaTime);
    }
    private void LateUpdate()
    {
        MainCamera.transform.position = (selfieRod / 2) + this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Finish")
        {
            Message.text = "You Win";
            other.gameObject.SetActive(false);
            Clock.enabled = false;
            this.gameObject.SetActive(false);
        }

        if (other.name == "Check1")
        {
            other.gameObject.SetActive(false);
            Gate1.isOpen = true;
        }
        if (other.name == "Check2")
        {
            other.gameObject.SetActive(false);
            Gate2.isOpen = true;
        }
    }
}
