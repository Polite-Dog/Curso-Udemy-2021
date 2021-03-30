using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField]
    private float force = 5;
    private float verticalInput;
    
    private GameObject focalPoint;

    
    public bool hasPowerUp;
    [SerializeField]
    private float powerUpForce;
    [SerializeField]
    private float powerUpTime;
    [SerializeField]
    private GameObject[] powerUpIndicators;

    private AudioSource _audioSource; 
    private float pitchAddition;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * 
            verticalInput * force);

        foreach(GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = transform.position + 0.5f * Vector3.down;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            
            StartCoroutine(PowerUpCountdown());
        }

        if (other.CompareTag("KillZone"))
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 ejectDirection = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(ejectDirection * powerUpForce, ForceMode.Impulse);

            
        }

        
    }
    IEnumerator PowerUpCountdown()
        {
        foreach(GameObject indicator in powerUpIndicators)
        {
            _audioSource.Play();
            _audioSource.pitch ++;
            _audioSource.loop = true;
            indicator.SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            indicator.SetActive(false);
            

        }

        hasPowerUp = false;
        
        _audioSource.pitch = 1;
        _audioSource.loop = false;
        _audioSource.Stop();

    }
}
