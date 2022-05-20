using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ColorChange : MonoBehaviour
{
   

    //colors
    Renderer rend;
    [SerializeField]
    List<Material> material = new List<Material>();

    TextMeshPro text;
    int valueOfBox;
    [SerializeField] int upperValueOfBox = 0;
    GameObject obj;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        valueOfBox = Random.Range(1, upperValueOfBox);
        obj = transform.GetChild(0).gameObject;
        text = obj.GetComponent<TextMeshPro>();
        text.text = valueOfBox.ToString();
        rend.material = material[valueOfBox - 1];
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "aiball" && valueOfBox > 1)
        {
            valueOfBox = valueOfBox - 1;
            text.text = valueOfBox.ToString();
            rend.material = material[valueOfBox - 1];
        }
        else if ((other.gameObject.tag == "aiball" && valueOfBox == 1))
        {
            ParticleSpawn.instance.SpawnParticle(transform.position);
            StaticObstacleSpawn.instance.RetunObj(gameObject);
        }
        if(other.gameObject.tag == "boundary")
        {
            ObstacleSpawn.instance.RetunObj(gameObject);
        }
        if(other.gameObject.CompareTag("player") && PowerUps.powerOn)
        {
            Score.instance.ScoreOnPowerOn(valueOfBox);
            ParticleSpawn.instance.SpawnParticle(transform.position);
            StaticObstacleSpawn.instance.RetunObj(gameObject);
        }
    }

   
}
