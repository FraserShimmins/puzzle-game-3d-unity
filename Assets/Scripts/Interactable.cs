using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1f; //The radius of the sphere
    public GameObject player; //Lets the script access player objects attributes
    protected bool hasInteracted = false;  //If the player has interacted with the object or not

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white; //Sets the color of the generated gizmos to 'red'
        Gizmos.DrawWireSphere(transform.position, radius); //Creates a Gizmo sphere our player can interact with
    }

    public virtual void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }


    void Update ()
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
}
