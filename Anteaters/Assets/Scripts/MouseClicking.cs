using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicking : MonoBehaviour
{

    Vector3 positionToMoveTo;

<<<<<<< Updated upstream
=======
    void Start()
    {
        
        positionToMoveTo = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

>>>>>>> Stashed changes
    // Update is called once per frame
    void Update() {
        
        if (Input.GetMouseButtonDown(0))
        {

            var hit = new RaycastHit();
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //transform.position = Input.mousePosition;

            float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
<<<<<<< Updated upstream
            positionToMoveTo = new Vector3(curPosition.x, Mathf.Max(0.5f, curPosition.y), transform.position.z);
=======
            positionToMoveTo = new Vector3(curPosition.x, curPosition.y, transform.position.z);
>>>>>>> Stashed changes

            //clickPosition.position = Input.mousePosition;
            //this gives a point that can be used as a component in other objects
        }

<<<<<<< Updated upstream
            transform.position += transform.position - positionToMoveTo;
        
=======
        transform.position = new Vector3((positionToMoveTo.x - transform.position.x) / 100 + transform.position.x, (positionToMoveTo.y - transform.position.y) / 100 + transform.position.y, transform.position.z);
>>>>>>> Stashed changes
        
    }
}

