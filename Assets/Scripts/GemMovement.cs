using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMovement : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("player") || other.gameObject.CompareTag("boundary"))
        {
            GemPooling.instance.AddToPool(gameObject);
            var obj=GemEffectPoolling.instance.GetFromPool();
            if(obj!=null)
            {
                obj.transform.position = transform.position;
                obj.GetComponent<ParticleSystem>().Play();
            }
        }
    }

}
