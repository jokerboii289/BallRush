using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemEffect : MonoBehaviour
{
    [SerializeField] float time;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {          
            StartCoroutine(EffectDisapper());
        }

    }
    IEnumerator EffectDisapper()
    {
        yield return new WaitForSeconds(time);
        GemEffectPoolling.instance.AddToPool(gameObject);
    }
}
