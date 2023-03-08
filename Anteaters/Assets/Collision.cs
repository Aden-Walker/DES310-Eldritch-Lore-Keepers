using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public TextTrigger textTrigger;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided");
        textTrigger.TriggerDialogue();
    }
}
