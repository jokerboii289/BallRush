using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    
    [SerializeField]bool moveright;
    [SerializeField]bool moveLeft;

    [SerializeField] float speed;
    Rigidbody rBody;
    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (moveright == true)
        {
            rBody.velocity += transform.right * speed * Time.fixedDeltaTime;

        }

        if(moveLeft==true)
        rBody.velocity += transform.right * -speed* Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("righttrigger"))
        {
            rBody.velocity = Vector3.zero;
            moveright = false;
            moveLeft = true;
        }
        if (other.gameObject.CompareTag("lefttrigger"))
        {
            rBody.velocity = Vector3.zero;
            moveLeft = false;
            moveright = true;
        }
    }
}
