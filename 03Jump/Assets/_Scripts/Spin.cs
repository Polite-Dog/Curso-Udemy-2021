using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float translateSpeed = 1;
    public float rotateSpeed = 60;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * Time.deltaTime * translateSpeed;
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }
}
