using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBallSpawn : MonoBehaviour
{
    [SerializeField] Transform turnPoint;
    public static AiBallSpawn instance;

    [SerializeField] float speedOfAiBall;
    [SerializeField] Transform playerPos;
    [SerializeField] float offset;
    [SerializeField]
    int burstSpawnLimit;
    [SerializeField] int startNo;
    [SerializeField] int limitOfSpawn;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for(int i=0;i<startNo;i++)
        {
            var obj = ObjectPooling.instance.GetFromPool();
            if (obj != null)
            {
                obj.transform.position = new Vector3(transform.position.x + Random.Range(-4, 4), playerPos.position.y, transform.position.z );
            }
        }
    }

    // Update is called once per frame
    void Update()
    {        
        if (!PlayerMovement.destroy && !PlayerMovement.turnRight)
        {
            GameObject[] activeAiBall = GameObject.FindGameObjectsWithTag("aiball");
            if (!PlayerMovement.reachedEndpoint || PauseMenu.playerDead)
            {
                if (limitOfSpawn > activeAiBall.Length)
                {
                    for (int i = 0; i < burstSpawnLimit; i++)
                    {
                        var obj = ObjectPooling.instance.GetFromPool();
                        if (obj != null)
                        {
                            obj.transform.position = new Vector3(transform.position.x + Random.Range(-3, 3), playerPos.position.y, playerPos.position.z - offset);
                        }
                    }
                }
            }
        }

        if(PlayerMovement.turnRight)
        {
            RightTurnSpawn();
        }
    }

    public float GetSpeed()
    {
        return speedOfAiBall;
    }
    
    public void RightTurnSpawn()
    {
        if (!PlayerMovement.destroy)
        {
            GameObject[] activeAiBall = GameObject.FindGameObjectsWithTag("aiball");
            if (!PlayerMovement.reachedEndpoint || PauseMenu.playerDead)
            {
                if (limitOfSpawn > activeAiBall.Length)
                {
                    for (int i = 0; i < burstSpawnLimit; i++)
                    {
                        var obj = ObjectPooling.instance.GetFromPool();
                        if (obj != null)
                        {
                            obj.transform.position = new Vector3(playerPos.position.x-offset, playerPos.position.y, turnPoint.position.z + Random.Range(-3, 3));
                        }
                    }
                }
            }
        }
    }
}
