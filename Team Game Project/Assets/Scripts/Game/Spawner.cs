﻿using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPointArray;
    public GameObject testEnemyPrefab;
    public GameManager gameManager;

    float spawnRate;      //time between each spawn. this will later be made dynamic to increase spawn rates
    float startSpawnAt = 1f;

    // Start is called before the first frame update
    void Start()
    {

        StartSpawning();
    }

    public void Update()
    {

        
        //spawnRate = UnityEngine.Random.Range(5 * Time.deltaTime, 10 * Time.deltaTime);
    }

    public void StartSpawning()
    {
        
        gameManager.levelNumber++;
        gameManager.numberOfEnemiesToSpawn += gameManager.levelNumber * gameManager.levelNumber;
        spawnRate = 6.9f - (0.1f * gameManager.levelNumber);
        Debug.Log(spawnRate);
        SpawnTest();
        InvokeRepeating("SpawnTest", startSpawnAt, spawnRate);
    }
    

    //make spawner repeat for number of times
    //when numebr of times is reached, end spawning
    //when all enemies are dead, end the level
    //when level is ended assign score and display menu
    //when chosen, load the next level.

    

    void SpawnTest()
    {
        // later include methods to make spawnrate decrease over time.time

        //int spawnPointIndex = Random.Range(0, spawnPointArray.Length); // implement something like this later for multiple spawns

        Instantiate(testEnemyPrefab, spawnPointArray[Mathf.FloorToInt(UnityEngine.Random.Range(0, 2))].position, spawnPointArray[0].rotation);
        gameManager.enemiesSpawned++;
        gameManager.numberOfEnemies++;
        if (gameManager.enemiesSpawned >= gameManager.numberOfEnemiesToSpawn)
        {
            Console.Write("DOne!");
            CancelInvoke();
        }
    }
}
