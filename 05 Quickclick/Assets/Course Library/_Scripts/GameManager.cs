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
    private GameObject titleScreen;

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


    /// <summary>
    /// Método que inicia la partida cambiando el valor del estado del juego
    /// </summary>

    private void Start()
    {
        ShowMaxScore();
    }

    public void StartGame(float difficulty)
    {
        
        
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget(difficulty));

        score = 0;
        UpdateScore(0);

        StartCoroutine(Countdown(countdownValue));
    }

    IEnumerator SpawnTarget(float _difficulty)
    {
        while(gameState == GameState.inGame)
        {
            float rate = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(rate/=_difficulty);
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


    const string MAX_SCORE = "MAX_SCORE";
    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Max Score: \n " + maxScore;
    }


    void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, score);
            //TODO: Fuegos artificiales

        }
    }
    
    public  void TimeOut()
    {
        SetMaxScore();
        ShowMaxScore();

        timeOutText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameState = GameState.timeOut;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
