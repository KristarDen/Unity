using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.0f); 

    }

    int move_triger = 1; //-1 left, 1 right
    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < 10f && move_triger == 1)
        {
            transform.position += new Vector3(0.05f, 0.0f);
            if (transform.position.x >= 10f)
            {
                move_triger = -1;
            }
        }
        else if (transform.position.x > -10f && move_triger == -1)
        {
            transform.position += new Vector3(-0.05f, 0.0f);
            if (transform.position.x <= -10f)
            {
                move_triger = 1;
            }
        }


    }
}
