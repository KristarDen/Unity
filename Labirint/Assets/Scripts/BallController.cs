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
    public Text CountOfChecks;

    

    private AudioSource[] sounds; // 0 - sound "touch of walls "1 - sound "check point get"


    public Rigidbody rb;

    private int KeyCount = 0;
    void Start()
    {
        forceDirection = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        Message = GameObject.Find("Message").GetComponent<Text>();
        CountOfChecks = GameObject.Find("CountOfChecks").GetComponent<Text>();
        Clock = GameObject.Find("Clock").GetComponent<Text>();
        selfieRod = MainCamera.transform.position - this.transform.position;

        sounds = GetComponents<AudioSource>();
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
            sounds[2].Play();
            other.gameObject.SetActive(false);
            Clock.enabled = false;
            while (sounds[2].isPlaying)
            {

            }
            this.gameObject.SetActive(false);
            return;
        }

        if (other.name == "Check1")
        {
            other.gameObject.SetActive(false);
            

            KeyCount += 1;
            CountOfChecks.text = $"{KeyCount}";
            if (!sounds[1].isPlaying)
            {
                sounds[1].volume = rb.velocity.magnitude / 2.3f;
                sounds[1].Play();
            }
            return;
        }
        if (other.name == "Check2")
        {
            other.gameObject.SetActive(false);

            KeyCount += 1;
            CountOfChecks.text = $"{KeyCount}";
            if (!sounds[1].isPlaying)
            {
                sounds[1].volume = rb.velocity.magnitude / 2.3f;
                sounds[1].Play();
            }

            return;
        }

        if (!sounds[0].isPlaying)
        {
            sounds[0].volume = rb.velocity.magnitude / 2.3f;
            sounds[0].Play();
        }

    }
}
