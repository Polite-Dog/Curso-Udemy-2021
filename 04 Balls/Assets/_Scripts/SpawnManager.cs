using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    
    private float spawnPosX = 9;
    private float spawnPosZ = 9;

    private float randomPosX;
    private float randomPosZ;

    private int remainingEnemies;
    [SerializeField]
    private int enemyWave = 1;
    public int waveCounter = 0;
    //Cantiad máxima de oleadas para aumentar numberOfPowerUps
    [SerializeField]
    private int amountOfWaves = 3;

    [SerializeField]
    private GameObject powerUpPrefab;
    public int numberOfPowerUps = 1;
    //Tiempo restante del power Up para desaparecer
    [SerializeField]
    private float RemainingTimeInScreen = 7;



    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaves(enemyWave);
        StartCoroutine(PowerUpRemainingTimeInScreen());
    }

    private void Update()
    {
        remainingEnemies = GameObject.FindObjectsOfType<Enemy>().Length;
        if(remainingEnemies == 0)
        {
            waveCounter++;
            if(waveCounter == amountOfWaves)
            {
                this.numberOfPowerUps++;
                waveCounter = 0;
            }
            
            enemyWave++;
            SpawnEnemyWaves(enemyWave);
            SpawnPowerUpsWaves(this.numberOfPowerUps);


            
            
            
        }
    }

    /// <summary>
    /// Genera una posición aleatoria en la zona de juego.
    /// </summary>
    /// <returns>Devuele un posición aleatoria dentro de la zona de juego</returns>
    private Vector3 RandomPositionGeneration()
    {
        
        randomPosX = Random.Range(spawnPosX, -spawnPosX);
        randomPosZ = Random.Range(spawnPosZ, -spawnPosZ);
        Vector3 randomSpawnPos = new Vector3(randomPosX, 0, randomPosZ);
        return randomSpawnPos;
        
    }

    /// <summary>
    /// Genera oleadas de enemigos en la zona de juego
    /// </summary>
    /// <param name="numberOfEnemies">cantidad de enemigos a generar</param>
    private void SpawnEnemyWaves(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, RandomPositionGeneration(), enemyPrefab.transform.rotation);
        }
    }

    /// <summary>
    /// Genera oleadas de power ups en la zona de juego
    /// </summary>
    /// <param name="numberOfPowerUps">Cantidad de power ups a generar</param>
    private void SpawnPowerUpsWaves(int numberOfPowerUps)
    {
        for (int i = 0; i < numberOfPowerUps; i++)
        {
            Instantiate(powerUpPrefab, RandomPositionGeneration(),
                               powerUpPrefab.transform.rotation);
        }
    }

    IEnumerator PowerUpRemainingTimeInScreen()
    {
        while(0 < 1)
        {
            yield return new WaitForSeconds(RemainingTimeInScreen);
            Destroy(GameObject.FindWithTag("PowerUp"));
        }
        

    }
}


