using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryButton : MonoBehaviour
{
    //Interactable Variables
    [SerializeField] private float radius = 1f; //The radius of the sphere
    [SerializeField] private GameObject player; //Lets the script access player objects attributes
    [SerializeField] private bool hasInteracted = false;  //If the player has interacted with the object or not
    
    //Setting the material of the button
    [SerializeField] private Material inActive;
    [SerializeField] private Material active;
    [SerializeField] private Material incorrect; 
    [SerializeField] private Renderer renderer;

    //Simon Game Manager
    [SerializeField] private Simon2 simonGame2;
    [SerializeField] private int colourIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

    //Called everytime the player is within the interaction radius 
    public void Interact()
    {
        if (hasInteracted == false && Input.GetKey(KeyCode.E))
        {
            simonGame2.PressButton(colourIndex);
        }      
    }

    public void Highlight()
    {
        renderer.material = active;
    }

    public void DeHighlight()
    {
        renderer.material = inActive;
    }

    public void Incorrect()
    {
        renderer.material = incorrect;
    }
}
