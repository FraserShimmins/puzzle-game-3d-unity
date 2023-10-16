using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPower2 : MonoBehaviour
{
    //Interactable Variables
    [SerializeField] private float radius = 1f; //The radius of the sphere
    [SerializeField] private GameObject player; //Lets the script access player objects attributes
    [SerializeField] private bool hasInteracted = false;  //If the player has interacted with the object or not
    [SerializeField] private PowerLineGrid2 powerLine;


    private bool isInteracting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            StartCoroutine(PressButton());
        }      
    }
    
    private IEnumerator PressButton()
    {
        powerLine.ShowConnection();
        yield return new WaitForSeconds(1f); 
        isInteracting = false;
    }

    //Stop the button from being interactable
    public void DeActivate()
    {
        hasInteracted = true;
    }
}
