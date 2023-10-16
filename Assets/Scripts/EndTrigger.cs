using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private GameManager manager;

    void OnTriggerEnter()
    {
        manager.WinGame();
    }
}
