using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    
    [Range(10, 30)]
    public float speed;
    
    public float xRange = 15f;
    public float zRange = 8f;

    public GameObject projectilePrefab;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //Movimiento del personaje
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right*Time.deltaTime*speed*horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (transform.position.x < -xRange)
        { 
            transform.position = new Vector3(x: -xRange, transform.position.y, transform.position.z); 
        }

        if (transform.position.x > xRange)
        { 
            transform.position = new Vector3(x: xRange, transform.position.y, transform.position.z); 
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, z: zRange);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, z: -zRange);
        }

        //Acciones del personaje

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + offset, projectilePrefab.transform.rotation);
        }

    }

}
