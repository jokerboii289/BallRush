using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBallMovement : MonoBehaviour
{
    
    Transform player;

    [SerializeField] float lerpSpeed=2f;  
    [SerializeField] float gravityModifier;
    [SerializeField] float rotateSpeed;

    Rigidbody rBody;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        rBody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        rBody.drag = 100;
    }
    // Start is called before the first frame update
    
    private void FixedUpdate()
    {
       
            var direction = player.position - rBody.position;
            direction.Normalize();
            rBody.position += direction * AiBallSpawn.instance.GetSpeed() * Time.deltaTime;
            rBody.position = Vector3.Lerp(rBody.position, new Vector3(player.position.x, rBody.position.y, rBody.position.z), lerpSpeed * Time.fixedDeltaTime);     
        
       
    }
    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -gravityModifier, 0);
        transform.RotateAround(Vector3.right, rotateSpeed * Time.deltaTime);
       
        if (PlayerMovement.turnRight)
        {
           // transform.forward = transform.right;
            
        }
    }
   
}
