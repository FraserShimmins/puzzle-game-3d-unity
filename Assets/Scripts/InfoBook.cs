using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBook : MonoBehaviour
{
    //Interactable Variables
    [SerializeField] private float radius = 1f; //The radius of the sphere
    [SerializeField] private GameObject player; //Lets the script access player objects attributes

    //Show prompt text variables
    [SerializeField] private bool textShown;
    [SerializeField] private GameObject promptText;

    //DisplayMessage variables
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private GameObject ui;

    //SoundEffects
    [SerializeField] private AudioSource openBook; //Soundeffect of openingNote


    void Start()
    {   
        textShown = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white; //Sets the color of the generated gizmos to 'red'
        Gizmos.DrawWireSphere(transform.position, radius); //Creates a Gizmo sphere our player can interact with
    }

    public virtual void Interact()
    {
        if (Input.GetKey(KeyCode.E))
        {
            openBook.Play();
            ui.SetActive(false);
            noteCanvas.SetActive(true);
        }
    }


    void Update ()
    {
        Vector3 playerPosition = player.transform.position; //Updates the position of the player
        float distance = Vector3.Distance(playerPosition, transform.position); //Distance between the player & the object
            
        if (distance <= radius)
        {
            //Interact
            if (textShown == false)
            {
                promptText.SetActive(true);
                textShown = true;
            }

            Interact();
        }

        else
        {
            if (textShown == true)
            {
                promptText.SetActive(false);
                textShown = false;
            }
        }
    }
        
}
