using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [Range(0, 20), SerializeField]
    private float speed = 5f;
    [Range(0, 50), SerializeField]
    private float turnSpeed = 5f;
    private float horizontalInput, verticalInput;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(speed*Time.deltaTime*Vector3.forward*verticalInput);
        transform.Rotate(turnSpeed*Time.deltaTime*Vector3.up*horizontalInput);
        



    }

}
