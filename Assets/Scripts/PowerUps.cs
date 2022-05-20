using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUps : MonoBehaviour
{
    //slider
    [SerializeField] GameObject sliderComponent;
    [SerializeField] Slider slider;
    float timer;

    [SerializeField] float powerTime; //time till power lasts
    public static bool powerOn;
    
   
    //player trail
    [SerializeField] List<GameObject> trails = new List<GameObject>();
    [SerializeField] GameObject powerCollectEfFect;
   

   
    // Start is called before the first frame update
    void Start()
    {
        sliderComponent.SetActive(false);
        slider.maxValue = powerTime;
        powerOn = false;
        trails[0].SetActive(true);
        trails[1].SetActive(false);
    }

    private void Update()
    {
        if (PowerUps.powerOn)
        {
            timer += 1 * Time.deltaTime;
            slider.value = timer;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("powerup"))
        {
            SoundManager.PlaySound("powerUp");
            powerCollectEfFect.transform.position = transform.position;
            powerCollectEfFect.GetComponent<ParticleSystem>().Play();
            powerOn = true;
            sliderComponent.SetActive(true);
            trails[0].SetActive(false);
            trails[1].SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(TimeLimit());
        }
        if(other.gameObject.CompareTag("obstacle") && powerOn )
        {
            SoundManager.PlaySound("boxBreak");
        }
    }

    IEnumerator TimeLimit()// time till power lasts
    {
        yield return new WaitForSeconds(powerTime);
        timer = 0;
        powerOn = false;
        trails[0].SetActive(true);
        trails[1].SetActive(false);
        sliderComponent.SetActive(false);        
    }

}
