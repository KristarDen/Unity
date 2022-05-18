using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    private AudioSource ball_n_kegel;
    private AudioSource kegel_n_kegel;
    private Rigidbody rb;
    private UserMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball_n_kegel = GetComponents<AudioSource>()[0];
        kegel_n_kegel = GetComponents<AudioSource>()[1];
        menu = GameObject.Find("UserMenuCanvas").GetComponent<UserMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kegel Collision" + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Kegel"))
        {
            float relv = (rb.velocity - collision.gameObject.GetComponent<Rigidbody>().velocity).magnitude;
            ball_n_kegel.volume = relv * menu.SoundSliderValue / 16;
            kegel_n_kegel.Play();
        }
        if (collision.gameObject.name.Equals("Ball"))
        {
            float relv = (rb.velocity - collision.gameObject.GetComponent<Rigidbody>().velocity).magnitude;
            ball_n_kegel.volume = relv * menu.SoundSliderValue / 7;
            ball_n_kegel.Play();
        }
    }
}
