using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameManager gameManager;
    [SerializeField]
    private ParticleSystem _particleSystem;

    private float minForce = 14, maxForce = 18, maxTorque = 10, 
        xSpawnRange = 4, ySpawnPos = -6;

    [SerializeField, Range(-100, 100)]
    private int pointValue;

    


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(),
            RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();

        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    
    /// <summary>
    /// Genera una fuerza aleatoria
    /// </summary>
    /// <returns>Devuelve una fuerza aleatoria con sentido hacia arriba</returns>
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
    
    /// <summary>
    /// Genera un torque aleatorio
    /// </summary>
    /// <returns>Devuelve un torque aleatorio entre -maxTorque y maxTorque</returns>
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    
    /// <summary>
    /// Genera una posición aleatoria de spawn
    /// </summary>
    /// <returns>Devuelve un Vector3 con X aleatoria, Y constante y Z = 0</returns>
    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos);
    }

    private void OnMouseOver()
    {
        if(gameManager.gameState == GameManager.GameState.inGame && 
            Input.GetMouseButton(0))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(_particleSystem, transform.position,
                _particleSystem.transform.rotation);
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Kill Zone"))
        {
            Destroy(gameObject);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
