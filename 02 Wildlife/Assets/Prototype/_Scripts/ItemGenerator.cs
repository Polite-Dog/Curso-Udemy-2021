using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;

    [SerializeField]
    private float spawnRangeZ, minSpawnRangeX, maxSpawnRangeX;

    private int itemIndex;

    private float startDelay = 7;
    private float counter;
    private float nextWaitTime = 3;

    private PlayerCtrl _playerCtrl;

    private bool _ammoInFloor;
    public bool ammoInFloor { get => _ammoInFloor; set => _ammoInFloor = value;}

    

    private void Start()
    {
        _playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }


    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime;
        if (counter > nextWaitTime && !_playerCtrl.gameOver && !_ammoInFloor)
        {
            Invoke("ItemGeneration", startDelay);
            counter = 0;
            nextWaitTime = Random.Range(7, 15);
            _ammoInFloor = true;
        }

    }

    void ItemGeneration()
    {

        Vector3 SpawnPos = new Vector3(Random.Range(minSpawnRangeX, maxSpawnRangeX),
            transform.position.y, Random.Range(spawnRangeZ, -spawnRangeZ));

        itemIndex = Random.Range(0, items.Length);
        Instantiate(items[itemIndex], SpawnPos, items[itemIndex].transform.rotation);
    }
}
