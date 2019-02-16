using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPointArray;
    public GameObject testEnemyPrefab;

    float spawnRate = 5f;      //time between each spawn. this will later be made dynamic to increase spawn rates
    float startSpawnAt = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTest", startSpawnAt, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnTest()
    {
        // later include methods to make spawnrate decrease over time.time

        //int spawnPointIndex = Random.Range(0, spawnPointArray.Length); // implement something like this later for multiple spawns

        Instantiate(testEnemyPrefab, spawnPointArray[0].position, spawnPointArray[0].rotation);
    }
}
