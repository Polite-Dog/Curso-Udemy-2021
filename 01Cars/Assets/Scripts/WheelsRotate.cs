using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsRotate : MonoBehaviour
{
    private float wheelRotate;
    private float forwardRotateSpeed = 360;
    private float backwardRotateSpeed = -360;
    // Update is called once per frame
    void Update()
    {
        wheelRotate = Input.GetAxis("Vertical");
        if (wheelRotate > 0){transform.Rotate(forwardRotateSpeed*Time.deltaTime*Vector3.right);}
        if (wheelRotate < 0) { transform.Rotate(backwardRotateSpeed * Time.deltaTime * Vector3.right); }
    }
}
