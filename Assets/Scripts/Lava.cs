using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : RevealingPath
{
    public Vector3 resetLocation = new Vector3(4.80f, 8.53f, -52.76f); //Location the player is sent back to
    [SerializeField] private AudioSource lavaSoundeffect; //Soundeffect of falling into lava

    // Update is called once per frame
    void Update()
    {
        if (selfCollider.bounds.Intersects(playerCollider.bounds))
        {
           player.transform.position = resetLocation;  
           lavaSoundeffect.Play();
        }
    }
}
