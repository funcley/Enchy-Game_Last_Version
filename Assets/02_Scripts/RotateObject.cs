using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject PivotObject;
    public float RotationSpeed;
    private CharacterController controller;
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    } 
    void Update()
    {
        
        //transform.Rotate(Time.deltaTime * RotationSpeed, 0, 0);

        
        transform.RotateAround(PivotObject.transform.position, Vector3.up, 90 * Time.deltaTime * RotationSpeed);
    }
}
