using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    private int ballIndex;

    private float counter = 0;
    private float nextWaitTime = 5f;
    [SerializeField]
    private int minWaitTime = 2;
    [SerializeField]
    private int maxWaitTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        
        // instantiate ball at random spawn location
        ballIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
    private void Update()
    {
        counter = Time.deltaTime + counter;
        if(counter >= nextWaitTime)
        {
            Invoke("SpawnRandomBall", startDelay);
            counter = 0;
            nextWaitTime = Random.Range(minWaitTime, maxWaitTime);
            
            
        }

    }
}
