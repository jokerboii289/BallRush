using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyEffect : MonoBehaviour
{
    public static PlayerDestroyEffect instance;
    [SerializeField] Transform playerPos;

    private void Awake()
    {
        instance = this;
    }
    public void PlayEffect()
    {
        transform.position = playerPos.position + new Vector3(0, 2f, 0);
        gameObject.GetComponent<ParticleSystem>().Play();
    }
}
