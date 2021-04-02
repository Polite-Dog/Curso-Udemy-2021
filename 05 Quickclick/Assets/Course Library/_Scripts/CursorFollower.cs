using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorFollower : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursosPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(cursosPos.x, cursosPos.y);
    }
}
