using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicking : MonoBehaviour
{

    Vector3 positionToMoveTo;
    float moveX, moveY, speed, conversionX, conversionY;
    void Start()
    {

        positionToMoveTo = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        moveX = 0.0f;
        moveY = 0.0f;
        speed = 2.0f;
        conversionX = 900.0f;
        conversionY = 1600.0f;

    }
    void Update()
    {

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

        if (positionToMoveTo.x - transform.position.x > 0.0f)
        {

            moveX = Mathf.Min((positionToMoveTo.x - transform.position.x) / conversionX + transform.position.x, speed / conversionX + transform.position.x);

        }
        else if (positionToMoveTo.x - transform.position.x < 0.0f)
        {

            moveX = Mathf.Max((positionToMoveTo.x - transform.position.x) / conversionX + transform.position.x, -speed / conversionX + transform.position.x);

        }
        else
        {

            moveX = 0.0f;

        }

        if (positionToMoveTo.y - transform.position.y > 0.0f)
        {

            moveY = Mathf.Min((positionToMoveTo.y - transform.position.y) / conversionY + transform.position.y, speed / conversionY + transform.position.y);

        }
        else if (positionToMoveTo.y - transform.position.y < 0.0f)
        {

            moveY = Mathf.Max((positionToMoveTo.y - transform.position.y) / conversionY + transform.position.y, -speed / conversionY + transform.position.y);

        }
        else
        {

            moveY = 0.0f;

        }

        transform.position = new Vector3(moveX, moveY, transform.position.z);

    }
}

