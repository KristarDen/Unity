using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick()
    {
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }
}
