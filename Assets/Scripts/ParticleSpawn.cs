using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawn : MonoBehaviour
{

    public static ParticleSpawn instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SpawnParticle(Vector3 pos)
    {
        var obj = ParticleSystemPool.instance.GetFromPool();
        if(obj!=null)
        {
            obj.transform.position = pos;
            obj.GetComponent<ParticleSystem>().Play();
        }
    }
}
