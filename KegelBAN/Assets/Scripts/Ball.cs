using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject Arrow;
    private UserMenu menu;

    private Rigidbody rb;
    private AudioSource ball_sound;
    private AudioSource ball_n_kegel_sound;
    private Vector3 forceDirection;
    private float forceMagnitude = 2000;
    private Vector3 ballStartPosition;
    private bool isBallReady;
    public Text Stat;

    private int move = 0;
    private int score = 0;
    private float moveStartTime;
    private float moveEndTime;
    private int kegelsTurn =0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball_sound = GetComponents<AudioSource>()[0];
        ball_n_kegel_sound = GetComponents<AudioSource>()[1];
        Stat = GameObject.Find("ScoreCount").GetComponent<Text>();
        forceDirection.Set(0, 0, 2000);
        ballStartPosition = this.transform.position;
        isBallReady = true;
        moveStartTime = 0;
        menu = GameObject.Find("UserMenuCanvas").GetComponent<UserMenu>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBallReady && Time.timeScale > 0f)
        {
            // rb.AddForce(forceDirection);
            rb.AddForce(ForceIndicator.ForceFactor * forceMagnitude * Arrow.transform.forward );
            isBallReady = false;

            Arrow.SetActive(false);
            moveStartTime = Time.time;

            
        }


        if(rb.velocity.magnitude < 1 && rb.velocity.magnitude > 1e-4)
        {
            /*rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.transform.position = ballStartPosition;*/
            OnBallStop();
            isBallReady = true;
        }
        else  // moving state
        {
            ball_sound.volume = rb.velocity.sqrMagnitude / 2000;
            if (!ball_sound.isPlaying) ball_sound.Play();

            // Debug.Log(rb.velocity.sqrMagnitude); - max = 1600
        }
    }

    private void OnBallStop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        this.transform.position = ballStartPosition;

        Arrow.SetActive(true);

        //Kegels position
        int KegelFall = 0;
        kegelsTurn = 0;
        foreach ( var kegel in GameObject.FindGameObjectsWithTag("Kegel"))
        {
            Debug.Log(kegel.name + " " + kegel.transform.position + " " + kegel.transform.rotation);

            if(kegel.transform.position.y > 0.2f)
            {
                //Debug.Log(kegel.name + " Down " + kegel.transform.position.y);
                kegel.SetActive(false);
                //Add score
                //Score.plusScore();
                KegelFall++;
            }
            else
            {
                //Debug.Log(kegel.name + " Up " + kegel.transform.position.y);
                kegel.transform.localPosition = Vector3.zero;
                kegel.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Rigidbody krb = kegel.GetComponent<Rigidbody>();
                krb.velocity = Vector3.zero;
                krb.angularVelocity = Vector3.zero;

                kegelsTurn++;

            }
        }
        moveEndTime = Time.time;
        //Display stat
        int moveTime = (int)Mathf.Ceil((moveEndTime - moveStartTime));
        move++;
        score += (move < 5
                ? KegelFall * (5 - move)
                : KegelFall) 
                * (moveTime < 10
                    ? 10 - moveTime : 1 );
        Stat.text += $"\n{move}\t{KegelFall}\t{score}\t{moveEndTime-moveStartTime}";

        moveStartTime = Time.time;

        GameStat.Moves.Add(new MoveData
        {
            Num = move,
            Time = moveTime,
            KegelsFall = KegelFall,
            Score = score
        });
        Debug.Log(kegelsTurn);
        if(kegelsTurn == 0)//Game over
        {
            UserMenu.IsShown = true;

           // UserMenu.buttonText.text = "Play Again";

            UserMenu.userMenuMode = UserMenuMode.GameOver;
        }
        /*
        UserMenu.IsShown = true;
        Time.timeScale = 0f;
        UserMenu.buttonText.text = "Continue";*/

        ball_sound.Stop();

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger" + other.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision" + collision.gameObject.name);

        if(collision.gameObject.CompareTag("Kegel"))
        {
            ball_sound.Stop();
            //ball_n_kegel_sound.Play();
        }
    }
}
