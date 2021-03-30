using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float counter;
    
    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime;
        if (counter >= 2)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                    Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                counter = 0;
            }
        }


        
        
    }
}
