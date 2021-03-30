using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private float spawnRangeZ, minSpawnRangeX, maxSpawnRangeX;

    private int enemieIndex;

    private float startDelay = 20;
    private float counter;
    private float nextWaitTime = 3;

    private PlayerCtrl _playerCtrl;

    private void Start()
    {
        _playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }


    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime;
        if(counter > nextWaitTime && !_playerCtrl.gameOver)
        {
            Invoke("EnemieGeneration", startDelay);
            counter = 0;
            nextWaitTime = Random.Range(1, 3);
        }
        
    }

    void EnemieGeneration()
    {
        
        Vector3 SpawnPos = new Vector3(Random.Range(minSpawnRangeX, maxSpawnRangeX),
            transform.position.y, Random.Range(spawnRangeZ, -spawnRangeZ));

        enemieIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemieIndex],SpawnPos, enemies[enemieIndex].transform.rotation);
    }
}
