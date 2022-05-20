using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //turnpoints
    public static bool turnRight;
    public static bool turnLeft;
    Vector3 tempPosition;
    [SerializeField] float tempSpeed;
    
    [SerializeField] float time;
    [SerializeField] float speed;


    //trigger enemy(side
    public static bool enemyTrigger;

    
  
    //panels
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject mainPanel;

    //make player to ground 
    [SerializeField] float gravityModifier;

    //endpoint detection
    public static bool reachedEndpoint = false;
    public static bool destroy = false;
   

    Rigidbody rBody;
    [SerializeField] float zSpeed;
    [SerializeField]
    float playerSpeed = 0f;//horizontal
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
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        

        if (!reachedEndpoint && !turnRight)
        {
            Physics.gravity = new Vector3(0, -gravityModifier, 0);
            rBody.velocity = Vector3.forward * zSpeed;
        }
        else if (!reachedEndpoint && turnRight) // turn Right
        {
            Physics.gravity = new Vector3(0, -gravityModifier, 0);
            rBody.velocity = Vector3.right * zSpeed;
        }
        else if(!reachedEndpoint && turnLeft)
        {
            Physics.gravity = new Vector3(0, -gravityModifier, 0);
            rBody.velocity = Vector3.left * zSpeed;
        }
        else
            rBody.velocity = Vector3.zero;

    }
    private void Update()
    {
        TurnRight();
        if (!reachedEndpoint && !turnRight)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    deltaPosX = touch.deltaPosition.x;
                    transform.localPosition = Vector3.Lerp(transform.position, new Vector3(transform.position.x + deltaPosX, transform.position.y, transform.position.z), playerSpeed * Time.deltaTime); 
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

        if(other.gameObject.CompareTag("door"))
        {
            destroy = true;
            StartCoroutine(DelayStop());
        }
     
        if(other.gameObject.CompareTag("turnright"))
        {
            ChangeDirection();
            tempPosition = transform.position;
            StartCoroutine(TempSpeed());
        }
        if (other.gameObject.CompareTag("turnleft"))
        {
            ChangeDirectionLeft();
            tempPosition = transform.position;
        }
    }

    IEnumerator DelayStop()
    {
        yield return new WaitForSeconds(2f);
        reachedEndpoint = true;
        if(!PauseMenu.playerDead)
        {
            SoundManager.PlaySound("win");
            winPanel.SetActive(true);
        }      
        mainPanel.SetActive(false);
    }
 

    void ChangeDirection()
    {
        transform.forward = (new Vector3(0,90,0));
        turnRight = true;
    }
    void ChangeDirectionLeft()
    {
        transform.forward = (new Vector3(0, -90, 0));
        turnLeft = true;
    }

    void TurnRight()
    {
        //turnright
        if (!reachedEndpoint && turnRight || !reachedEndpoint &&  turnLeft)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    deltaPosX = touch.deltaPosition.x;          
                    transform.localPosition = Vector3.Lerp(transform.position, new Vector3(transform.position.x , transform.position.y , transform.position.z - deltaPosX), playerSpeed * Time.deltaTime);
                }
            }
        }
        if (turnRight ||turnLeft)
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Clamp(transform.localPosition.z, -6.7f+tempPosition.z, 6.7f + tempPosition.z));
    }

    IEnumerator TempSpeed()
    {
        zSpeed = tempSpeed;
        yield return new WaitForSeconds(time);
        zSpeed = speed;
    }

    

    

}
