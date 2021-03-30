using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private  GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;
    
    //variables InvokeRep.
    [SerializeField]
    private float startDelay = 2.0f;
    [SerializeField]
    private float spawnRate = 2f;

    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnPos = this.transform.position;
        InvokeRepeating("SpawnObstacles", startDelay, spawnRate);   
    }

    void SpawnObstacles()
    {
        if(!_playerController.GameOver)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab,
            spawnPos,
            obstaclePrefab.transform.rotation);
        }
        
    }
    
}
