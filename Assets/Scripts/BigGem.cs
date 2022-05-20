using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGem : MonoBehaviour
{
    [SerializeField] List<GameObject> bigGem = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < bigGem.Count; i++)
        {
            var rand = Random.Range(0, 2);
            if(rand==1)
            {
                bigGem[i].SetActive(true);
            }
        }
    }

   
}
