using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    int count = 0;

    public static bool jump=false;
   
    Transform target;
    

    [SerializeField]
    PlayerMovement sript;
    [SerializeField] float timer;
    
    public Rigidbody ball;  

    public float h = 25;
    public float gravity = -18;


    private void Update()
    {   
        if(Input.touchCount>0)    //multiple jumps for count
        {
            count++;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("jump"))
        {
            SoundManager.PlaySound("jump");
            jump = true;
            sript.enabled = false;
            target = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>();
            Physics.gravity = Vector3.up * gravity;
            ball.velocity = CalculateLaunchVelocity();
            StartCoroutine(DelayScript());

        }
    }
   
    Vector3 CalculateLaunchVelocity()
    {
        float distanceY = target.position.y - ball.position.y;
        Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * h / gravity)+Mathf.Sqrt(2*(distanceY-h)/gravity));
        return velocityXZ + velocityY;
    }

    IEnumerator DelayScript()
    {
        yield return new WaitForSeconds(timer);
        jump = false;
        sript.enabled = true;
    }    
}
