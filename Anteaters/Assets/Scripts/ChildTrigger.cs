using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    public GameObject child;

    // when the trigger is collided with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the object that is colliding with the trigger is the player then increment the childs movement
        if(collision.name == "Player")
            child.GetComponent<ChildBehaviour>().IncrementMovement();
    }

   
}
