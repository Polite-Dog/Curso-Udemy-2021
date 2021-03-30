using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 5+Time.time / 100;
        if (!_playerController.GameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }
}
