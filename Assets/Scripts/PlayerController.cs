using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    public LayerMask movementMask;
    MovePlayer move;
    

    void Start()
    {
        cam = Camera.main;
        move = GetComponent<MovePlayer>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                move.MoveToPoint(hit.point);   //Calls the MoveToPoint method moving the player
            }
        }
    }
}
