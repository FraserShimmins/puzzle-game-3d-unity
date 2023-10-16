using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLineManager2 : MonoBehaviour
{
    //Interactable Variables
    private float radius; //The radius of the sphere
    [SerializeField] private GameObject player; //Lets the script access player objects attributes
    [SerializeField] private bool hasInteracted = false;  //If the player has interacted with the object or not

    //GameManager
    GameManager manager;
    public GameObject gameManager;
    [SerializeField] private PowerLineGrid2 gameGrid;
    public GameObject grid;


    //Rotation Variables
    public Vector3 rotationAxis = Vector3.up; // The axis you want to rotate around
    public float rotationAmount = 90.0f; // The amount to rotate each time
    public bool isRotating = false;

    //Which connection points are present & where
    [SerializeField] private bool nConnector; // ^  
    [SerializeField] private bool eConnector; // >
    [SerializeField] private bool sConnector; // v
    [SerializeField] private bool wConnector; // <

    //PowerRealtedVariables
    [SerializeField] private bool powered; 
    [SerializeField] private GameObject[] lines; //ListContaining all the powerline 3D objects
    [SerializeField] private Material dePoweredMaterial;
    [SerializeField] private Material poweredMaterial;

    //Location Realted Variables
    [SerializeField] private int row;
    [SerializeField] private int column;
    [SerializeField] private Renderer objectRenderer; //Used to prevent checks if the object is not rendered
    
    
    void Start()
    {
        radius = 1.5f;
        powered = false;
        gameManager = GameObject.FindWithTag("GameManager");
        manager = gameManager.GetComponent<GameManager>();
        objectRenderer = GetComponent<Renderer>();
        grid = GameObject.FindWithTag("PowerLineManager2");
        gameGrid = grid.GetComponent<PowerLineGrid2>();
    }

    void Update()
    {
        if (hasInteracted == false)
        {
            Vector3 playerPosition = player.transform.position; //Updates the position of the player
            float distance = Vector3.Distance(playerPosition, transform.position); //Distance between the player & the object
            
            if (distance <= radius)
            {
                //Interact
                Interact();
            }
        }
    }

    public void PowerUpdate()
    {
        if (hasInteracted == false)
        {
            if (powered == false && gameGrid.checkSurrondings(row, column, nConnector, eConnector, sConnector, wConnector) == true)
            {
                PowerUp();
            }

            /*
            else if (powered == true && gameGrid.checkSurrondings(row, column, nConnector, eConnector, sConnector, wConnector) == false)
            {
                PowerDown();
            }
            */
        }

    }
    
    //Called everytime the player is within the interaction radius 
    public void Interact()
    {
        if (hasInteracted == false && Input.GetKey(KeyCode.E) && !isRotating)
        {
            manager.PlayRotate();
            StartCoroutine(RotateBy90Degrees());
            
            //Rotate all the connection points
            bool[] tempArray = {nConnector, eConnector, sConnector, wConnector};
            nConnector = tempArray[3];
            eConnector = tempArray[0];
            sConnector = tempArray[1];
            wConnector = tempArray[2];
        }      
    }
    
    
    //Makes the object apear powered apon it being connected to electricity
    public void PowerUp()
    {
        powered = true;

        foreach (GameObject line in lines) 
        {
            line.GetComponent<Renderer>().material = poweredMaterial;
        }
    }

    //Makes the object apear depowered apon it being not connected to electricity
    public void PowerDown()
    {
        powered = false;

        foreach (GameObject line in lines) 
        {
            line.GetComponent<Renderer>().material = dePoweredMaterial;
        }
    }

    public bool GetNorth()
    {
        return nConnector;
    }

    public bool GetEast()
    {
        return eConnector;
    }

    public bool GetSouth()
    {
        return sConnector;
    }

    public bool GetWest()
    {
        return wConnector;
    }

    public bool GetPowered()
    {
        return powered;
    }

    //Stop the button from being interactable
    public void DeActivate()
    {
        hasInteracted = true;
    }

    //Rotates the object by 90 degrees, also rotating all the conection points
    IEnumerator RotateBy90Degrees()
    {
        isRotating = true;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(rotationAxis * rotationAmount) * initialRotation;
        float elapsedTime = 0f;
        float rotationDuration = 0.2f; // Time it takes to complete the rotation in seconds

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;
    }


    //Show the radius in the scene window
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white; //Sets the color of the generated gizmos to 'red'
        Gizmos.DrawWireSphere(transform.position, radius); //Creates a Gizmo sphere our player can interact with
    }
}
