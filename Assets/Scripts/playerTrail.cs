using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrail : MonoBehaviour
{
   
    [SerializeField] Transform playerPos; 
    [SerializeField] Vector3 offset;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position+new Vector3(.3f,0,-.2f)+offset;
      
      
        if (PauseMenu.playerDead)
        {
            gameObject.SetActive(false);
        }
        
        if(PlayerMovement.turnRight)
        {
            gameObject.SetActive(false);
        }
    }


}
