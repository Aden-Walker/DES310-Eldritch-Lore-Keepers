using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    public GameObject child;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
            child.GetComponent<ChildBehaviour>().IncrementMovement();
    }

   
}
