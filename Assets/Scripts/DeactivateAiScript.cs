using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAiScript : MonoBehaviour
{
    [SerializeField] AiBallMovement aiScript;

    // Update is called once per frame
    void Update()
    {
        if (PlayerJump.jump)
        {
            aiScript.enabled = false;
        }
        
        if(!PlayerJump.jump)
        {
            aiScript.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            aiScript.enabled = false;
            Score.instance.ScoreUpdate();
            Effect();                      // ai ball destroy effect
            ObjectPooling.instance.AddToPool(gameObject);
        }
        if (other.gameObject.CompareTag("door"))
        {
            Effect();
            ObjectPooling.instance.AddToPool(gameObject);
        }
        if(other.gameObject.CompareTag("destroyball"))
        {         
            aiScript.enabled = false;
            ObjectPooling.instance.AddToPool(gameObject);
        }
       
           
    }
    void Effect()
    {
        var obj = AiEffectPool.instance.GetFromPool();
        if (obj != null)
        {
            obj.transform.position = transform.position;
            obj.GetComponent<ParticleSystem>().Play();
            SoundManager.PlaySound("ballPop");
        }

    }

}
