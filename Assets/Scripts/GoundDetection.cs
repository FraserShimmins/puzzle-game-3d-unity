using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundDetection : MonoBehaviour
{
    //Defining attributes
    public Transform target;  //Player positon
    

    void LateUpdate()
    {
        transform.position = target.position;  //Makes the detector follow the player
    }
}
