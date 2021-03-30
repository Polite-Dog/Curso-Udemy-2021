using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    
    
    private PlayerCtrl _playerCtrl;
    private ItemGenerator _itemGenerator;

    
    // Start is called before the first frame update
    void Start()
    {
        _playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        _itemGenerator = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Enemie"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            if (_playerCtrl.projectilesRemainig < 30)
            {
             _playerCtrl.projectilesRemainig += Random.Range(5, 20);
            }
            _itemGenerator.ammoInFloor = false;   
        }

        if (other.CompareTag("Enemie"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bounds"))
        {
            Destroy(this.gameObject);
        }
    }

}
