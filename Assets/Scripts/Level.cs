using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    Gyroscope gyro;

    private void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    void Update()
    {
        Vector3 rot = new Vector3(-gyro.rotationRate.x, 0, -gyro.rotationRate.y);

        transform.Rotate(rot);
    }
}
