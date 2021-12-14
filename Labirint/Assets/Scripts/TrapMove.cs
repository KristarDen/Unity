using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    public float speed = 5f;

    private bool direction = false;
    public float touchForce = 300F;
    void Start()
    {
       
    }

    void Update()
    {
        if (direction == false)
        {
            if(transform.position.y >= -2f)
            {
                this.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else direction = true;
        }

        if(direction == true )
        {
            if (transform.position.y <= 0.55f)
            {
                this.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else direction = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Ball")
        {
            other.attachedRigidbody.AddForce(new Vector3(0f , 1f, 0.5f) * touchForce);
        }
    }
    


}
