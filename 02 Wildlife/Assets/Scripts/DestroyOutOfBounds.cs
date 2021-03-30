using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField]
    private float topFrontier = 50f;
    [SerializeField]
    private float lowerFrontier = -8f;
    // Update is called once per frame
    void Update()
    {
        // OR = || / AND = &&
        
        if (transform.position.z > topFrontier)     
        {
            Destroy(this.gameObject);
        }

        if (transform.position.z < lowerFrontier)
        {
            Destroy(this.gameObject);
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
