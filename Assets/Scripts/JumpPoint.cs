using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    [SerializeField] Vector3 newScale;
    [SerializeField] float time;
    Vector3 originalScale;
    bool scale = false;

    [SerializeField] ParticleSystem particle;

    private void Start()
    {
        originalScale = transform.localScale;
    }
    void Update()
    {
        if (scale)
            transform.LeanScale(newScale, time);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            particle.Play();
            scale = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(time);
        scale = false;
        transform.LeanScale(originalScale, time);
    }
}
