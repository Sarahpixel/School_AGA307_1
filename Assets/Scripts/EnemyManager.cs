using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints; // spawn point for our enemies
    public GameObject[] enemyTypes; //contains our different enemy types
    public List<GameObject> enemies; //a list containing our enemies
    public string[] enemyNames;
    public string playerName = "Sarah";
    public int spawnCount=10;
    public string killCondition = "Two";


    void Start()
    {
        //enemies.Add(enemyTypes[0]);
        //enemies.Add(enemyTypes[1]);
        //enemies.Add(enemyTypes[2]);
        //enemies.Add(enemyTypes[3]);
       
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnEnemy();
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        
        {
            SpawnEnemy();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            KillAllEnemies();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            KillSpecificEnemy(killCondition);
        }
    }
    void SpawnEnemy()
    {
        //spawns a random enemy at a random spawn point
        int enemyNumber = Random.Range(0, enemyTypes.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject enemy=Instantiate(enemyTypes[enemyNumber], spawnPoints[spawnPoint].position, spawnPoints[spawnPoint].rotation,transform);
        enemies.Add(enemy);
        print(enemies.Count);
        
        //for(int i =0; i < enemyTypes.Length; i++)
        //{
        //    print(i+1);
        //}
    }
    void spawnEnemies()
    {
        //this will spawn an enemy at each spawn point
     
        for (int i =0; i <spawnPoints.Length; i++)
        {
            GameObject enemy = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], spawnPoints[i].position, spawnPoints[i].rotation, transform);
            enemies.Add(enemy);
        }
    }
    /// <summary>
    /// kills a specific enemy in our game
    /// </summary>
    /// <param name="_enemy">the enemy we wish to kill</param>
    void KillEnemy(GameObject _enemy)
    {
        if(enemies.Count == 0)
            return;
        Destroy(_enemy);
        enemies.Remove(_enemy);
        ////Destroy(enemies[0]);
        //Destroy(enemies[enemies.Count]);
        ////enemies.RemoveAt(0);
        //enemies.RemoveAt(enemies.Count-1);

        print(enemies.Count);
    }

    void KillSpecificEnemy(string _condition)
    {
        for (int i = 0; i <enemies.Count; i++)
        {
            if (enemies[i].name.Contains(_condition)) //any that contains we kill the enemies
                KillEnemy(enemies[i]);
        }
    }

    void KillAllEnemies()
    {
        if (enemies.Count == 0)
            return ;

        for(int i =0;i < enemies.Count; i++)
        {
            Destroy(enemies[i]);
           
        }
        enemies.Clear();
    }
}
