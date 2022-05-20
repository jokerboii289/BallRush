using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRolling : MonoBehaviour
{
    [SerializeField]AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.playerDead && !PlayerJump.jump)
        {
            audioSrc.enabled = true;
        }
        if(PauseMenu.playerDead || PlayerMovement.destroy|| PlayerJump.jump)
        {
            audioSrc.enabled = false;
        }    
    }
}
