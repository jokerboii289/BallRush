using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSplineMovement : MonoBehaviour
{
    //player holder
    [SerializeField] Transform playerHolder;
    [SerializeField] float rotateSpeed;

    //turnpoints
    public static bool turnRight;
    public static bool turnLeft;
    Vector3 tempPosition;

    //trigger enemy(side
    public static bool enemyTrigger;


    [SerializeField]
    float playerSpeed;
    //panels
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject mainPanel;

   

    //endpoint detection
    public static bool reachedEndpoint = false;
    public static bool destroy = false;


    
    Touch touch;
    float deltaPosX;


    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    private void OnEnable()
    {
        turnRight = false;
        ////
        enemyTrigger = false;
        destroy = false;
        reachedEndpoint = false;
        winPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    private void Start()
    {
         transform.position = playerHolder.position;
         gameObject.transform.SetParent(playerHolder);
    }


    private void Update()
    {
        //set player to playerholder
        transform.RotateAround(transform.up, rotateSpeed * Time.deltaTime);
        if (!reachedEndpoint && !turnRight)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    deltaPosX = touch.deltaPosition.x;
                    if(deltaPosX<0)
                    {
                        transform.Rotate(new Vector3(0, -45, 0));
                    }
                    transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x + deltaPosX, transform.localPosition.y ,transform.localPosition.z), playerSpeed * Time.deltaTime);
                }
            }
        }

        if (!turnRight)
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -6.7f, 6.7f), transform.localPosition.y, transform.localPosition.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("aiball"))
        {
            PauseMenu.pause.PlayerDead();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle") && !PowerUps.powerOn || other.gameObject.CompareTag("triggerdeath"))
        {
            PlayerDestroyEffect.instance.PlayEffect();
            PauseMenu.pause.PlayerDead();
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("gem"))
        {
            SoundManager.PlaySound("gemcollect");
            Score.instance.AddGempoints();
        }

        if (other.gameObject.CompareTag("door"))
        {
            destroy = true;
            StartCoroutine(DelayStop());
        }

        

    }

    IEnumerator DelayStop()
    {
        yield return new WaitForSeconds(2f);
        reachedEndpoint = true;
        if (!PauseMenu.playerDead)
        {
            SoundManager.PlaySound("win");
            winPanel.SetActive(true);
        }
        mainPanel.SetActive(false);
    }


}
