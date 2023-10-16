using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSimonGame2 : MonoBehaviour
{
    //Interactable Variables
    [SerializeField] private float radius = 1f; //The radius of the sphere
    [SerializeField] private GameObject player; //Lets the script access player objects attributes
    [SerializeField] private bool hasInteracted = false;  //If the player has interacted with the object or not
    [SerializeField] private Simon2 simonGame2;
    private bool isInteracting;

    void Start()
    {
        isInteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position; //Updates the position of the player
        float distance = Vector3.Distance(playerPosition, transform.position); //Distance between the player & the object
            
        if (distance <= radius)
        {
            //Interact
            Interact();
        }
    }
    

    //Called everytime the player is within the interaction radius 
    public void Interact()
    {
        if (hasInteracted == false && Input.GetKey(KeyCode.E) && !isInteracting)
        {
            Debug.Log("NEW GAME");
            isInteracting = true;
            PressButton();
        }      
    }
    
    private void PressButton()
    {
        simonGame2.StartNewGame();
        isInteracting = false;
    }
    
}
