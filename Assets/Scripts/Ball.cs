using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [Range(1, 5)]
    public float speed;
    private Rigidbody body;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Vector3 tilt = Quaternion.Euler(90, 0, 0) * Input.acceleration;
        Vector3 planTilt = new Vector3(tilt.x, 0, tilt.z);

        body.AddForce(planTilt * speed);
    }
}
