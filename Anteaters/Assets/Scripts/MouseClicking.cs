using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicking : MonoBehaviour
{
    public Transform clickPosition;
    public Transform playerPosition;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition.position = Input.mousePosition;
            //this gives a point that can be used as a component in other objects
        }
        
        
    }
}

