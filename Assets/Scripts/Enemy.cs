using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform moveToPos;
    public float mySpeed = 2f;
    public float myHealth = 100f;
    public EnemyType mytype;
    public PatrolType myPatrol;

    //manager class
    EnemyManager _EM;

    [Header("AI")]
    int patrolPoint=0;
    bool reverse=false;
    Transform startpos;
    Transform endpos;
    Transform movePos;
    void Start()
    {
        _EM = FindObjectOfType<EnemyManager>();
        //funtion return
        moveToPos = _EM.GetRandomSpawnPoint();
        StartCoroutine(Move());
    }
    void SetupAI()
    {
        startpos =Instantiate(new GameObject(),transform.position,transform.rotation). transform;
        endpos =_EM.GetRandomSpawnPoint();
        moveToPos = endpos;


    }
    void Setup()
    {
        switch (mytype)
        {
            case EnemyType.OneHand:
                myHealth = 100f;
                mySpeed = 2f;
                myPatrol=PatrolType.Linear;
                break;
               
            case EnemyType.TwoHand:
                myHealth = 200f;
                mySpeed = 1f;
                myPatrol=PatrolType.Loop;
                break;
            case EnemyType.Archer:

                myHealth = 50f;
                mySpeed = 3f;
                myPatrol = PatrolType.Random;
                break;  
        }


        if (mytype == EnemyType.OneHand)
        {
            myHealth = 100f;
            mySpeed = 2f;
        }
     
        if(mytype == EnemyType.TwoHand)
        {
            myHealth = 200f;
            mySpeed = 1f;
        }
         
        if(mytype == EnemyType.Archer)
        {
            myHealth = 50f;
            mySpeed = 3f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        switch (myPatrol)
        {
            case PatrolType.Linear:
                moveToPos = _EM.spawnPoints[patrolPoint];
                //? = TRUE then := FALSE
                patrolPoint = patrolPoint != _EM.spawnPoints.Length ? patrolPoint + 1 : 0;
                break;

            case PatrolType.Random:
                moveToPos=_EM.GetRandomSpawnPoint();
                break;

            case PatrolType.Loop:
                moveToPos=reverse?startpos:endpos;
                reverse=!reverse;
                break;
        }



        //moveToPos = _EM.GetRandomSpawnPoint();
        transform.LookAt(moveToPos);
       while (Vector3.Distance(transform.position, moveToPos.position) > 0.3f)
        {
            //changes the speed for the enemies depends on the numerals added 
            //transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, Time.deltaTime * mySpeed);
            transform.rotation = Quaternion.LookRotation(moveToPos.position);
            yield return null;  
        }
        yield return new WaitForSeconds(1);

        StartCoroutine(Move());
        
    }
}
