using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{

    [Header("obstacle points")]
    [SerializeField] List<GameObject> points = new List<GameObject>();
    


    [Header("Time till game last")]
    [SerializeField] float timeLimit;
    private float timeCounter=0;
    
    [SerializeField] GameObject endPoint;

    /// <summary>
    /// ///
    /// </summary>
    [SerializeField]
    List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField]
    float offset = 2f;
    float posX;

    public static ObstacleSpawn instance;
    [SerializeField] float timeInterval=1f;
    float nextTimeToSpawn=0;

    //random obstacle spawn
    [SerializeField] int upperLimit;
    List<int> pointCheck;

    List<int> gemPoints;


    private void Start()
    {
        endPoint.SetActive(false);
        gemPoints = new List<int>();
        pointCheck = new List<int>();
        instance = this;

        for(int i=0;i<spawnPoints.Count;i++)
        {
            spawnPoints[i].transform.position = new Vector3(-8 + posX, transform.position.y, transform.position.z);
            posX = posX + offset;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //time till game lasts
        timeCounter += 1 * Time.deltaTime;
       
        
        if (Time.time > nextTimeToSpawn && timeCounter<timeLimit)
        {
            nextTimeToSpawn = Time.time + timeInterval;
            timeCounter += 1;
            
            GenerateLimit();
            for(int i=0;i<pointCheck.Count;i++)
            {
                var obj = ObstaclePooling.instance.GetFromPool();
                if (obj != null)
                {
                    obj.transform.position = spawnPoints[pointCheck[i]].transform.position;
                }
            }

            
            //gemSpawnPoints
            var rand = Random.Range(0,2); // randomness of gem spawn
            if (rand == 0)
            {
                GetGemPoints();
                SpawnGem();
            }
            
            //clearing gem points
            gemPoints.Clear();

            //clearing poincheck temporary list
            pointCheck.Clear();         
        } 

        if(timeCounter>timeLimit)
        {
            endPoint.SetActive(true);
        }
    }

    public void RetunObj(GameObject obj)
    {
        ObstaclePooling.instance.AddToPool(obj);
    }
    
    int RandomPosX()
    {
        return Random.Range(0, spawnPoints.Count);
    }


    void GenerateLimit()
    {
        var limit = Random.Range(1, upperLimit);// limit no of obstacles in row;
        
        for(int i=0;i<limit;i++)
        {
            if(pointCheck==null)
            {
                pointCheck.Add(RandomPosX());
            }
            else
            {
                var pos=CheckPreviousPos(RandomPosX());
                while(pos==0)
                {
                    pos = CheckPreviousPos(RandomPosX());
                    continue;
                }
                pointCheck.Add(pos);
            }
        }
    }

    int CheckPreviousPos(int posX)
    {
        bool count = false;
        for(int i=0;i<pointCheck.Count;i++)
        {
            if(posX==pointCheck[i])
            {
                count = true;
                var pos = RandomPosX();
                CheckPreviousPos(pos);
                
            }
        }
        if(count==false)
        {
            return posX;
        }

        return 0;
    }
   

    void GetGemPoints()
    {
        
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            bool emptyPoint = true;
            for (int j = 0; j < pointCheck.Count; j++)
            {
                if (i == pointCheck[j])
                {
                    emptyPoint = false;
                    break;
                }
            }
            if(emptyPoint==true)
            {
                gemPoints.Add(i); //getting empty points
            }           
        }
    }
    
    void SpawnGem()
    {
        var count = 0;
        for(int i=0;i<gemPoints.Count;i++)
        {
            var rand=Random.Range(0,2);
            if(rand==0 && count<=2)
            {
                var obj = GemPooling.instance.GetFromPool();
                if (obj != null)
                {
                    obj.transform.position = spawnPoints[gemPoints[i]].transform.position;
                    count++;
                }

            }
            
        }
        count = 0;
    }
}
