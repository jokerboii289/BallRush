using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrail : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    ParticleSystem trail;
    private void Start()
    {
        trail = GetComponent<ParticleSystem>();
        trail.Pause();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position + new Vector3(.3f, .0f, -.2f);
        if (PauseMenu.playerDead)
        {
            gameObject.SetActive(false);
        }
    }
}
