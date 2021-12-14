using UnityEngine;
using System.Collections;
public class MouseLook : MonoBehaviour
{
    public GameObject Axis;

    private Vector3 selfieRod;
    public GameObject target;
    float horizontal = 0 ;
    float vertical = 0;
    void Start()
    {
        Axis = GameObject.Find("Axis");
        selfieRod = transform.position - Axis.transform.position;
        horizontal = 0f;
    }
    public float movementSpeed = 10;
    public float turningSpeed = 60;

    void Update()
    {
        selfieRod = Quaternion.Euler(0, horizontal, 0) * selfieRod; 
        transform.position = (selfieRod / 1) + Axis.transform.position;

        horizontal = Input.GetAxis("Mouse X") * turningSpeed * Time.deltaTime;
        transform.RotateAround(Axis.transform.position,Vector3.up, horizontal);
        //transform.RotateAround(Axis.transform.position, Vector3.forward, horizontal);

        vertical = Input.GetAxis("Mouse Y") * turningSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right, -vertical);

        Axis.transform.Rotate(Vector3.up, horizontal);
        //transform.Rotate(vertical, 0 , 0);

        
    }
}