using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] float time;
    private void Update()
    {
        StartCoroutine(EffectDisapper());
    }
    IEnumerator EffectDisapper()
    {
        yield return new WaitForSeconds(time);
        GemEffectPoolling.instance.AddToPool(gameObject);
    }
}
