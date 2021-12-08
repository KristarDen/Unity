using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate1 : MonoBehaviour
{
    public static bool isOpen = false;
    public static bool isSlowOpen = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(isOpen == true)
        {
            if(this.transform.position.y > -1f)
            {
                this.transform.Translate(Vector3.down * Time.deltaTime);
            }
            else
            {
                isOpen = false;
            }
            
        }
        else if (isSlowOpen == true)
        {
            if (this.transform.position.y > -1f)
            {
                this.transform.Translate((Vector3.down * 0.1f) * Time.deltaTime);
            }
            else
            {
                isSlowOpen = false;
            }
        }
    }
}
