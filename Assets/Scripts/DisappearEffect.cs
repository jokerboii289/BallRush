using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearEffect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Disapper());
    }

    IEnumerator Disapper()
    {
        yield return new WaitForSeconds(2f);
        AiEffectPool.instance.AddToPool(gameObject);
    }
}
