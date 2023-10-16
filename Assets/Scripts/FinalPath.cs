using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPath : MonoBehaviour
{
    public ZoneVisibility zone;
    private MeshRenderer meshRenderer;
    public bool activated;
    public GameObject player;
    protected Collider playerCollider;
    protected Collider selfCollider;
    GameManager manager;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        selfCollider = GetComponent<Collider>();
        playerCollider = player.GetComponent<Collider>();
        activated = false;
        gameManager = GameObject.FindWithTag("GameManager"); //Get the gameManager object
        manager = gameManager.GetComponent<GameManager>(); //Gets the gameManager script attached to that object 
    }

    // Update is called once per frame
    void Update()
    {
        if (selfCollider.bounds.Intersects(playerCollider.bounds) && activated == false)
        {
            activated = true;
            manager.LavaCleared();
        }

        if (zone.visibility == true && activated == true)
        {
            meshRenderer.enabled = true;
        }

        else
        {
            meshRenderer.enabled = false;
        }
    }
}
