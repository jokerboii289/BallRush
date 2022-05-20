using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform toRotate;
    [SerializeField] Transform playerPos;
    [SerializeField] float offset;
    [SerializeField] float offsetY;
    [SerializeField] Vector3 cameraOffet;
    
    [SerializeField] float speed;

    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
    }
    private void LateUpdate()
    {
        
        if(!PlayerMovement.destroy && !PlayerMovement.turnRight)
        transform.position = new Vector3(originalPos.x, playerPos.position.y + offsetY, playerPos.position.z + offset);     
        
        if(PlayerMovement.turnRight)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotate.rotation, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, toRotate.position,speed* Time.deltaTime );
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y + offsetY, toRotate.position.z + offset) +cameraOffet;

        }
        
    }

}
