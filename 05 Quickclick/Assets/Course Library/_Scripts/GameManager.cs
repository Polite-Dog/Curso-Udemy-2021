using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targetPrefab;

    [SerializeField]
    private float minSpawnRate = 0.5f, maxSpawnRate = 1.5f;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while(0 < 1)
        {
            float rate = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(rate);
            int index = Random.Range(0, targetPrefab.Count);
            Instantiate(targetPrefab[index]);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
