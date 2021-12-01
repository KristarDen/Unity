using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTube : MonoBehaviour
{
    float MoveVelocity = 2;
    GameObject Top;
    GameObject Bottom;
    public float _distance = 0;
    Dropdown hardSet;
    void Start()
    {
        Top = this.transform.GetChild(1).gameObject;
        Bottom = this.transform.GetChild(2).gameObject;
        hardSet = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        this.SetDistance();
    }


    void Update()
    {
        transform.Translate(Vector2.left * MoveVelocity * Time.deltaTime);
    }

    public void SetDistance()
    {
        SetDefaultDistance();
        int type = hardSet.value;
        float distance = 0;
        switch (type)
        {
            case 0 :
                distance = 0.7f;
                _distance = 0.7f;
                break;
            case 1:
                distance = 0.5f;
                _distance = 0.5f;
                break;
            case 2:
                distance = 0;
                _distance = 0;
                break;
            default:
                distance = 0;
                _distance = 0;
                break;
        }
        this.Top.transform.Translate(Vector2.up * distance);
        this.Bottom.transform.Translate(Vector2.down * distance);
        Debug.Log("type : " + type + "vector_up : " + Vector2.up * distance);
    }
    public void SetDistance2(float distance)
    {
        Top.transform.Translate(Vector2.up * distance);
        Bottom.transform.Translate(Vector2.down * distance);
    }
    void SetDefaultDistance()
    {
        this.Top.transform.Translate(Vector2.down * _distance);
        this.Bottom.transform.Translate(Vector2.up * _distance);
    }


}
