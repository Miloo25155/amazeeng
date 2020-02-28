using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Rigidbody body;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        body.AddForce(Input.acceleration);
    }
}
