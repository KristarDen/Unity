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

        float value = Random.Range(-3.0f, 3.0f);
        collision.gameObject.transform.parent.transform.parent.transform.position = new Vector3(11.1f, value, 0f);
        //collision.gameObject.transform.parent.transform.parent.GetComponent<MoveTube>().SetDistance2(GetComponent<MoveTube>()._distance);
        Debug.Log(collision.name);
    }
}
