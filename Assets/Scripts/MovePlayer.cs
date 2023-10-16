using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;    //Brings the navMeshAgent into the script
    [SerializeField] private GameObject ui;

    void Start()
    {   
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    public void MoveToPoint (Vector3 point)
    {
        //If the UI is hidden (Looking at Note) then don't move the player
        if (ui.activeInHierarchy == true)
        {
            agent.SetDestination(point); //Sets the desintation of the navMeshAgent to where the player clicked
        }

    }
}
