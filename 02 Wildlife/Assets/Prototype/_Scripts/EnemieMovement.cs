using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private PlayerCtrl _playerCtrl;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerCtrl.gameOver)
        {
          transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed/2);
        }

    }
    
}
