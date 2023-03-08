using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public TextTrigger textTrigger;
    private void OnTriggerEnter2D(Collider2D col)
    {
        textTrigger.TriggerDialogue();
    }
}
