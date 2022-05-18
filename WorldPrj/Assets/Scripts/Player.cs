using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public const int CAM_H_FACTOR = 5;
    public const int CAM_V_FACTOR = 5;

    private float COIN_SPAWN_OFFSET_Y = 1.5f;

    public Camera cam;
    public GameObject CoinPrefab;
    public Canvas UInterface;
    public Text CoinDistance;
    private Vector3 rod;
    private Vector3 rodCopy;
    private Vector3 camAngles;
    private Vector3 ccMove;
    private CharacterController characterController;
    private Animator animator;
    private float camStartAngleY;
    private float characterSpeed = 10.0f;

    public float jumpSpeed = 800.0f;
    public float jumpDuration = 100.0f;
    public float jumpCurrDuration = 0.1f;
    public float gravity = 20.0f;

    private GameObject toDestroy;
    GameObject coin;
    private float timeout;

    // Start is called before the first frame update
    void Start()
    {

        camAngles = Vector3.zero;
        characterController = GetComponent<CharacterController>();
        rod = characterController.transform.position - cam.transform.position;
        rodCopy = rod;
        camStartAngleY = cam.transform.rotation.eulerAngles.y;

        animator = GetComponentInChildren<Animator>();


        coin = GameObject.Find("Coin");
        if(coin != null)
        {
            COIN_SPAWN_OFFSET_Y = coin.transform.position.y 
                - Terrain.activeTerrain.SampleHeight(coin.transform.position); ;
        }
        else
        {
            COIN_SPAWN_OFFSET_Y = 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
            float dH = Input.GetAxis("Mouse X") * CAM_H_FACTOR;
		    float dV = Input.GetAxis("Mouse Y") * CAM_V_FACTOR;

            cam.transform.Rotate(dH, dV, 0);
        */

        camAngles.y += Input.GetAxis("Mouse X") * CAM_H_FACTOR;
        camAngles.x -= Input.GetAxis("Mouse Y") * CAM_V_FACTOR;
        cam.transform.eulerAngles = camAngles;
      
        cam.transform.position = characterController.transform.position - 
            Quaternion.Euler(0, camAngles.y - camStartAngleY, 0) * rod;

        //this.transform.eulerAngles.Set( 0, camAngles.y, 0); 
        Vector3 playerAngles = Vector3.zero;
        playerAngles.y = camAngles.y;
        this.transform.eulerAngles = playerAngles;
        
        // Character move
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        ccMove = cam.transform.right * mH + cam.transform.forward * mV;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.SimpleMove((ccMove * 3) * characterSpeed);
            animator.speed = 5.0f;
        }
        
        else
        {
            characterController.SimpleMove(ccMove * characterSpeed);
            animator.speed = 1.0f;
        }

        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                animator.SetInteger("PlayerState", 3);
                jumpCurrDuration = jumpDuration;
               
            }
            
        }
        else
        {
            if (jumpCurrDuration > 0.2f)
            {
                ccMove.y += jumpSpeed * Time.deltaTime;
                characterController.Move(ccMove);
                jumpCurrDuration -= 0.1f;
            }
            
        }
        
            

        if (characterController.velocity.magnitude > 0.00001f)
        {
            if(Mathf.Abs(mH) > Mathf.Abs(mV))
            {
                animator.SetInteger("PlayerState", 2);
            }
            else
            {
                animator.SetInteger("PlayerState", 1);
            }

        }
       
        else
        {
            animator.SetInteger("PlayerState", 0);
        }

        if (Input.GetButton("Jump"))
        {
            animator.SetInteger("PlayerState", 3);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale =
                Time.timeScale == 0
                ? 1
                : 0;
            Debug.Log(Time.timeScale);
        }
    }

    private void LateUpdate()
    {
        if (toDestroy != null)
        {
            if (timeout <= 0)
            {
                GameObject.Destroy(toDestroy.transform.parent.gameObject);
                toDestroy = null;
            }
            else timeout -= Time.deltaTime;
        }
        UInterface.GetComponent<UIscript>().SetCoinDistance(
                    distaceBetween(this.transform.position, coin.transform.position));

        if (Input.GetKeyDown( KeyCode.H) )
        {
            CamCoinAngle();
        }
        UInterface.GetComponent<UIscript>().RotateArrow(CamCoinAngle());

        Vector2 msd = Input.mouseScrollDelta;
        if(msd.magnitude > 0)
        {
            Debug.Log(msd);
            if (msd.y > 0) rod *= 1.05f;
            if (msd.y < 0) 
            {
                rod /= 1.05f;
                if(rod.magnitude < 4f)
                {
                    rod = rodCopy * 0.2f;
                }
                Debug.Log(rod.magnitude);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // Debug.Log("OnTriggerEnter " + other.name);

            if (toDestroy == null)
            {
                other.gameObject.GetComponent<Animator>().SetInteger("CoinState", 1);

                UInterface.GetComponent<UIscript>().CoinScorePlusOne();


                

                Vector3 spawnPosition = Vector3.zero;
                do
                {
                    spawnPosition.Set(
                        this.transform.position.x + Random.Range(-10, 10),
                        this.transform.position.y,
                        this.transform.position.z + Random.Range(-10, 10));

                } while ((spawnPosition - this.transform.position).magnitude < 5);


                spawnPosition.y = COIN_SPAWN_OFFSET_Y + Terrain.activeTerrain.SampleHeight(spawnPosition);
                coin = GameObject.Instantiate(
                    CoinPrefab,
                    spawnPosition,
                    Quaternion.identity
                    );
                
                toDestroy = other.transform.gameObject;
                timeout = 0.5f;

            }
            // Задача: разместить монету случайным образом,
            //  но не ближе, чем 5, не дальше чем 10 единиц до Player
            // Рекомендация: цикл случайных генераций +
            //  проверка расстояния как магнитуды разности векторов
        }
    }

    private float distaceBetween(Vector3 a, Vector3 b)
    {
        float res;
        res = ( Mathf.Sqrt( Pow(b.x - a.x) + Pow(b.y - a.y) + Pow(b.z - a.z)) );
        return res;
    }

    private float Pow( float num)
    {
        return (num * num);
    }

    private float CamCoinAngle()
    {
        // this.transform.position - player position / (cam)
        // coin.transform.position - coin position /
        // cam.transform.forward - camera "sight" direction * ---- 0 (Coin)
        // angle = Acos( (v1,v2) / |v1||v2| )
        Vector3 v1 = cam.transform.forward;
        Vector3 v2 = coin.transform.position - this.transform.position;
        float angle = Mathf.Acos(Vector3.Dot(v1, v2) / v1.magnitude / v2.magnitude);

        Vector3 v3 = Vector3.Cross(v1, v2);

        if(v3.y < 0)
        {
            angle = -angle;
        }

        //Debug.Log(angle * 180/ Mathf.PI + " " + v3);
        //Debug.Log(Vector3.SignedAngle(v1, v2, Vector3.up));

        return (angle * 180 / Mathf.PI);
    }
}
