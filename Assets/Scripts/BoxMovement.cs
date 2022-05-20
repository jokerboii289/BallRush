using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    Rigidbody rBody;
    [SerializeField]
    float speed=0;
      
    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
       
    private void FixedUpdate()
    {
        //movement of box
        rBody.velocity = Vector3.forward * -speed;
        
    } 

}
