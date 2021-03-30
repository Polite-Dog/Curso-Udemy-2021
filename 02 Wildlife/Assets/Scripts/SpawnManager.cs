using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    private int animalIndex;
    private float spawnRangeX = 15;
    private float spawnPosZ;

    [SerializeField, Range(1f, 5f)]
    private float startDelay;
    [SerializeField, Range(0.5f, 3.0f)]
    private float spawnInterval;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosZ = this.transform.position.z;

        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }


    private void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(x: Random.Range(-spawnRangeX, spawnRangeX), y: 0, spawnPosZ);

        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex], spawnPos, enemies[animalIndex].transform.rotation);
    }

    
}
