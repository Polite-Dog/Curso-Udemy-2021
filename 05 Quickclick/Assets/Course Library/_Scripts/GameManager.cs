using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        loading,
        inGame,
        timeOut
    }

    public GameState gameState;
    
    
    
    
    
    [SerializeField]
    private List<GameObject> targetPrefab;

    [SerializeField]
    private float minSpawnRate = 0.5f, maxSpawnRate = 1.5f;

    [SerializeField]
    private TextMeshProUGUI scoreText, timeOutText, counterText;
    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private int timeToWait, countdownValue = 60;

    private int _score;
    private int score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 99999);
        }
        get
        {
            return _score;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.inGame;
        
        StartCoroutine(SpawnTarget());
        
        score = 0;
        UpdateScore(0);
        
        StartCoroutine(Countdown(countdownValue));
    }

    IEnumerator SpawnTarget()
    {
        while(gameState == GameState.inGame)
        {
            float rate = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(rate);
            int index = Random.Range(0, targetPrefab.Count);
            Instantiate(targetPrefab[index]);
        }
        
    }
    
    IEnumerator Countdown(int counter)
    {
        
        while(counter > 0)
        {
            yield return new WaitForSeconds(timeToWait);
            --counter;
            counterText.text = "Remaining Time: \n" + counter;
        }
        if(counter == 0)
        {
            TimeOut();
        }
    }

    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        
    }

    
    public  void TimeOut()
    {
        timeOutText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameState = GameState.timeOut;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
