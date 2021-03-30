using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField, Range(0, 10)]
    private float moveSpeed = 10;
    [SerializeField, Range(0, 360)]
    private float rotateSpeed = 10;

    private float horizontalInput, verticalInput;

    private Rigidbody _rigidbody;

    [SerializeField]
    private GameObject projectiles;

    [SerializeField]
    private bool _gameOver;
    public bool gameOver { get => _gameOver; }

    [SerializeField]
    private int _projectilesRemaining = 15;
    public int projectilesRemainig { get => _projectilesRemaining; set => _projectilesRemaining = value; }



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (!_gameOver)
        {
            MovePlayer();
        }
            

        if (Input.GetKeyDown(KeyCode.Space) && !_gameOver && _projectilesRemaining > 0) 
        {
            FireProjetiles();
            _projectilesRemaining -= 1;
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemie"))
        {
            Destroy(this.gameObject);
            _gameOver = true;
        }
    }

    void MovePlayer()
    {
        transform.Translate(Vector3.forward * moveSpeed * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * horizontalInput * Time.deltaTime);

    }

    void FireProjetiles()
    {
        
        
            Instantiate(projectiles, transform.position, projectiles.transform.rotation);
        
    }

    
}
