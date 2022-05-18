using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject Pivot;
    public float rightEnd = 51f;
    public float leftEnd = 314.8f;

    private AudioSource squeak;

    void Start()
    {
        squeak = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log(this.transform.rotation.eulerAngles.ToString());
            if (this.transform.rotation.eulerAngles.y >= leftEnd || this.transform.rotation.eulerAngles.y == 0f)
            {
                this.transform.RotateAround(
                                Pivot.transform.position,
                                Vector3.up,
                                - 20 * Time.deltaTime);

                if( ! squeak.isPlaying)
                {
                    squeak.Play();
                }
            }
            if ( ((int)this.transform.rotation.eulerAngles.y) <= ((int)rightEnd) && this.transform.rotation.eulerAngles.y < 360f)
            {
                this.transform.RotateAround(
                               Pivot.transform.position,
                               Vector3.up,
                               - 20 * Time.deltaTime);

                if (!squeak.isPlaying)
                {
                    squeak.Play();
                }
            }

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log(this.transform.rotation.eulerAngles.ToString());
            if (this.transform.rotation.eulerAngles.y <= rightEnd)
            {
                this.transform.RotateAround(
                Pivot.transform.position,
                Vector3.up,
                20 * Time.deltaTime);

                if (!squeak.isPlaying)
                {
                    squeak.Play();
                }
            }
            if ( this.transform.rotation.eulerAngles.y > rightEnd && this.transform.rotation.eulerAngles.y > 300f)
            {
                this.transform.RotateAround(
                Pivot.transform.position,
                Vector3.up,
                20 * Time.deltaTime);

                if (!squeak.isPlaying)
                {
                    squeak.Play();
                }
            }
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (!squeak.isPlaying)
            {
                squeak.Stop();
            }
        }
    }
}
