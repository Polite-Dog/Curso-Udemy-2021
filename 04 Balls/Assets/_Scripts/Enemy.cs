using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveForce;

    private Rigidbody _rigidbody;

    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
        _rigidbody.AddForce(lookDirection * moveForce, ForceMode.Force);

        if(this.transform.position.y < -16)
        {
            Destroy(gameObject);
        }
    }
}
