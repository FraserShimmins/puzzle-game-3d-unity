using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : Interactable
{
    //Attributes
    GameManager manager;
    public GameObject gameManager;

    //Setting the material of the button
    public Material inActive;
    public Material active;
    public Renderer renderer;

    //miscellaneous
    public string order; //The order that the button comes in the sequence
  

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager"); //Get the gameManager object
        manager = gameManager.GetComponent<GameManager>(); //Gets the gameManager script attached to that object 
        renderer = GetComponent<Renderer>(); //Gets the Mesh Render of the button
        renderer.material = inActive; //Set button to grey
    }

    public override void Interact()
    {

        if (hasInteracted == false && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Button Pressed!");
            renderer.material = active; //Change the button to yellow
            manager.ButtonPress(order); //Button has been pressed
            hasInteracted = true;
        }
    }

    public void Reset()
    {
        renderer.material = inActive;
        hasInteracted = false;
    }

    
}
