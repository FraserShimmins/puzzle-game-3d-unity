using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : MonoBehaviour
{
    [SerializeField] private GameObject connectedNode;
    [SerializeField] private PowerLineManager connectedManager;

    //RENDERER ATTRIBUTES
    [SerializeField] private GameObject[] lines; //ListContaining all the powerline 3D objects
    [SerializeField] private Material dePoweredMaterial;
    [SerializeField] private Material poweredMaterial;


    // Start is called before the first frame update
    void Start()
    {
        connectedManager = connectedNode.GetComponent<PowerLineManager>();
    }

    //Used to start the electricity accross the powerlines
    public void StartPowerUp()
    {
        PowerUp();

        if (connectedManager.GetPowered() == false && connectedManager.GetWest() == true)
        {
            connectedManager.PowerUp();
        }

        else if (connectedManager.GetPowered() == true && connectedManager.GetWest() == false)
        {
            connectedManager.PowerDown();
        }
    }


    //Makes the object apear powered apon it being connected to electricity
    public void PowerUp()
    {
        foreach (GameObject line in lines) 
        {
            line.GetComponent<Renderer>().material = poweredMaterial;
        }
    }

    //Makes the object apear depowered apon it being not connected to electricity
    public void PowerDown()
    {
        foreach (GameObject line in lines) 
        {
            line.GetComponent<Renderer>().material = dePoweredMaterial;
        }

        //Make connected node powerDown
        connectedManager.PowerDown();
    }
}
