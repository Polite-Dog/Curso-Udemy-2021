using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float minForce = 14, maxForce = 18, maxTorque = 10, 
        xSpawnRange = 4, ySpawnPos = -6;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(),
            RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition(); 
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
    
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    
    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
