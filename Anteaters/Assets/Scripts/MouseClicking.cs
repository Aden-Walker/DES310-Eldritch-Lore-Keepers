using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicking : MonoBehaviour
{
    //more or less the player class

    Animator animator;

    Vector3 positionToMoveTo;
    float moveX, speed, conversionX, conversionY;
    void Start()
    {
        animator = GetComponent<Animator>();
        //positionToMoveTo = new Vector3(-4.25f, transform.position.y, transform.position.z);
        moveX = 0.0f;
        speed = 20.0f;
        conversionX = 900.0f;
        conversionY = 1600.0f;

    }
    void Update()
    {
        bool moving = false;
        if ((Input.GetMouseButtonDown(0)) && (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(gameObject.transform.position).z)).y < 0))
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
            moving = true;
        }
        else if (positionToMoveTo.x - transform.position.x < 0.0f)
        {

            moveX = Mathf.Max((positionToMoveTo.x - transform.position.x) / conversionX + transform.position.x, -speed / conversionX + transform.position.x);
            moving = true;
        }
        else if (Mathf.Abs(positionToMoveTo.x - transform.position.x) < 0.01f)
        {

            moveX = 0.0f;
            moving = false;
        }
        else
        {

            moveX = 0.0f;
            moving = false;

        }


        animator.SetBool("IsMoving", moving);
        transform.position = new Vector3(moveX, -2.2f, transform.position.z);

    }
}

