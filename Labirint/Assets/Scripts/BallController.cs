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

    static public float volume;

    private AudioSource[] sounds; // 0 - sound "touch of walls "1 - sound "check point get"
    private AudioSource FinalSound;
    public Toggle IsGameSound;

    bool GameSound;

    public Rigidbody rb;

    private int KeyCount = 0;

    public GameObject Menu;

    void Start()
    {
        forceDirection = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        Message = GameObject.Find("Message").GetComponent<Text>();
        CountOfChecks = GameObject.Find("CountOfChecks").GetComponent<Text>();
        Clock = GameObject.Find("Clock").GetComponent<Text>();
        selfieRod = MainCamera.transform.position - this.transform.position;

        IsGameSound = GameObject.Find("SoundsOnToggle").GetComponent<Toggle>();
        IsGameSound.onValueChanged.AddListener(delegate { GameSoundCheck(); });
        
        FinalSound = GameObject.Find("UI").GetComponents<AudioSource>()[1];
        sounds = GetComponents<AudioSource>();

        Menu = GameObject.Find("Menu");
        GameSoundCheck();
    }

    void Update()
    {
        forceDirection.x = Input.GetAxis("Horizontal");
        forceDirection.z = Input.GetAxis("Vertical");

        rb.AddForce(forceDirection * ForceFactor * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0f;
        }
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

            if( GameSound == true)
            {
                FinalSound.volume = volume;
                FinalSound.Play();
            }
            
            other.gameObject.SetActive(false);
            Clock.enabled = false;
            
            this.gameObject.SetActive(false);
            return;
        }

        if (other.name == "Check1")
        {
            other.gameObject.SetActive(false);
            

            KeyCount += 1;
            CountOfChecks.text = $"{KeyCount}";
            if (!sounds[1].isPlaying && GameSound == true)
            {
                sounds[1].volume = rb.velocity.magnitude / volume;
                sounds[1].Play();
            }
            return;
        }
        if (other.name == "Check2")
        {
            other.gameObject.SetActive(false);

            KeyCount += 1;
            CountOfChecks.text = $"{KeyCount}";
            if (!sounds[1].isPlaying && GameSound == true)
            {
                sounds[1].volume = rb.velocity.magnitude / volume;
                sounds[1].Play();
            }

            return;
        }
        
        if (!sounds[0].isPlaying && GameSound == true)
        {
            sounds[0].volume = rb.velocity.magnitude / volume;
            sounds[0].Play();
        }

    }

    void GameSoundCheck()
    {
        GameSound = IsGameSound.isOn;
    }
}
