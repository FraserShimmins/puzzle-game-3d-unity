using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Defining attributes
    public Transform target;  //Player positon
    public Vector3 offset;   //Camera offset 
    //public float pitch = 2f;    //Verticle camera offset

    void LateUpdate()
    {
        transform.position = target.position - offset;  //Makes the camera follow the player by a set offset
        //transform.LookAt(target.position + Vector3.up * pitch);  //Angle the camera based off the bottom of the player

    }
}
