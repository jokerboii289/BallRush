using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confettiBlast : MonoBehaviour
{
    [SerializeField] List<GameObject> particleSystem = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<particleSystem.Count;i++)
        {
            particleSystem[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.destroy)
        {
            for (int i = 0; i < particleSystem.Count; i++)
            {
                particleSystem[i].SetActive(true);
            }
        }
    }
}
