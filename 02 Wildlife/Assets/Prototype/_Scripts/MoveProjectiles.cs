using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectiles : MonoBehaviour
{
    private GameObject player;
    [SerializeField, Range(0, 50)]
    private float shootSpeed;

    private PlayerCtrl _playerCtrl;

    

    // Start is called before the first frame update
    void Start()
    {
        _playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(player.transform.forward * Time.deltaTime * shootSpeed);
    }
}
