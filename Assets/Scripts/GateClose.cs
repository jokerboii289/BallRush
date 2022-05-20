using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateClose : MonoBehaviour
{
    [SerializeField] float yPos;
    [SerializeField] float time;
   
    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.destroy)
        {
            LeanTween.moveLocalY(gameObject, yPos, time);
        }
    }
}
