using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    // checks to see if player enters the trigger. 
    void OnTriggerEnter2D(Collider2D other)
    {
        // checking to see if player has entered the trigger.
        if (other.gameObject.GetComponent<Player>())
        {
            //Getting pawn to get checkpoint.
            Pawn pawn = other.gameObject.GetComponent<Pawn>();
            //setting pawn to this spot.
            pawn.lastCheckpoint = transform;
        }
    }
}
