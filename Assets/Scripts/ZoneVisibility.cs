using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneVisibility : MonoBehaviour
{
    private MeshRenderer meshRenderer; 
    public bool visibility; //IS the object visible?

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        visibility = false;
    }

    void Start()
    {
        meshRenderer.enabled = false; //When the game first begins none of the grid spots are visible
    }

    void OnTriggerEnter(Collider other) 
    {
        meshRenderer.enabled = true;
        visibility = true;   
    }
    
    void OnTriggerExit(Collider other) 
    {
        meshRenderer.enabled = false;
        visibility = false;
    }

}
