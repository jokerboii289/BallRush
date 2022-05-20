using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    [SerializeField] float speed;
    
    Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rBody.velocity = Vector3.forward * -speed;
        StartCoroutine(ReturnParticle());
    }

    IEnumerator ReturnParticle()
    {
        yield return new WaitForSeconds(2f);
        ParticleSystemPool.instance.AddToPool(gameObject);
    }
    
}
