using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffectSecond : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    ParticleSystem trail;
    [SerializeField] Vector3 offset;
    private void Start()
    {
        trail = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.turnRight)
        transform.position = playerPos.position + new Vector3(.3f, 0, -.2f) + offset;

        if (PauseMenu.playerDead)
        {
            gameObject.SetActive(false);
        }

        
    }
}
