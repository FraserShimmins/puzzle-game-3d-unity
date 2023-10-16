using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    GameManager manager;
    public GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }

    public override void Interact()
    {
        manager.CollectCoin();
        hasInteracted = true;
        Destroy(gameObject, 0f);
        
    }
}
