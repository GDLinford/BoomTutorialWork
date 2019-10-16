using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    void Update()
    {
        //Grabs the rotation
        Vector3 euler = transform.rotation.eulerAngles;
        // Adds rotation X and Y based on keyboard movement
        euler.x += Input.GetAxis("Vertical");
        euler.y -= Input.GetAxis("Horizontal");
        //Assigns the rotation
        transform.rotation = Quaternion.Euler(euler);
    }
}
