using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVisibility : MonoBehaviour
{
    public ZoneVisibility zone;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (zone.visibility == true)
        {
            meshRenderer.enabled = true;
        }

        else
        {
            meshRenderer.enabled = false;
        }
    }
}
