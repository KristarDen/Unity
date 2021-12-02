using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEnd : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
     {

        if(collision.gameObject.transform.parent.transform.parent.gameObject.tag == "Tube")
        {
            float value = Random.Range(-2.5f, 2.5f);
            collision.gameObject.transform.parent.transform.parent.transform.position = new Vector3(11.1f, value, 0f);
            //collision.gameObject.transform.parent.transform.parent.GetComponent<MoveTube>().SetDistance2(GetComponent<MoveTube>()._distance);
            Debug.Log(collision.name);
        }

        else if (collision.gameObject.name == "Egg-pixel" || collision.gameObject.name == "Bug" )
        {
            collision.gameObject.SetActive(false);
        }
        
        else if( collision.gameObject.name == "Spawn")
        {
            collision.gameObject.transform.position = new Vector3(16.13f, 0.72f, 0f);
        }
        
    }
}
