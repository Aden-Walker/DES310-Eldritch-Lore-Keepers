using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicking : MonoBehaviour
{

    Vector3 positionToMoveTo;
    void Start()
    {
        
        positionToMoveTo = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
    void Update() {
        
        if (Input.GetMouseButtonDown(0))
        {

            var hit = new RaycastHit();
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //transform.position = Input.mousePosition;

            float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
            positionToMoveTo = new Vector3(curPosition.x, curPosition.y, transform.position.z);

            //clickPosition.position = Input.mousePosition;
            //this gives a point that can be used as a component in other objects
        }
        
        transform.position = new Vector3((positionToMoveTo.x - transform.position.x) / 100 + transform.position.x, (positionToMoveTo.y - transform.position.y) / 100 + transform.position.y, transform.position.z);
        
    }
}

