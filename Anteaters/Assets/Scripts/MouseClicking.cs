using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicking : MonoBehaviour
{
    //more or less the player class

    //Animator for the Anteater
    Animator animator;

    Vector3 positionToMoveTo; //The position that we hope to get to.
    float moveX, speed, conversionX, conversionY; //A bunch of movement variables, moveX is how far we move in the horizontal direction, speed is how fast we go and the Conversion variables determine the rate at which speeds are divided.
    bool facingRight = true; //A variable to check if the anteater is facing right or not. Used for Flipping.
    void Start()
    {
        //We are initializing all of our variables here.
        animator = GetComponent<Animator>(); //Starts the animator? - Dominic
        positionToMoveTo = new Vector3(-4.25f, transform.position.y, transform.position.z); //Initialize our two movement points to be the starting position to prevent null values.
        transform.position = new Vector3(-4.25f, transform.position.y, transform.position.z);
        moveX = 0.0f;
        speed = 20.0f;
        conversionX = 900.0f;
        conversionY = 1600.0f;

    }
    void Update()
    {
        bool moving = false; //We make sure that moving is false every frame until we determine it is true.
        if ((Input.GetMouseButtonDown(0)) && (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(gameObject.transform.position).z)).y < 0))
        {

            var hit = new RaycastHit(); //A raycast for detection
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //A ray itself seeing where the mouse is.

            //transform.position = Input.mousePosition;

            float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //How far away is the objects from the screen.
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen)); //The position we are at currently with our mouse
            positionToMoveTo = new Vector3(curPosition.x, curPosition.y, transform.position.z); //Where are we going? Where are we off to?
            //clickPosition.position = Input.mousePosition;
            //this gives a point that can be used as a component in other objects
        }

        if (positionToMoveTo.x - transform.position.x > 0.0f) //Now we try to see if we are moving in the right direction.
        {

            moveX = Mathf.Min((positionToMoveTo.x - transform.position.x) / conversionX + transform.position.x, speed / conversionX + transform.position.x); //We move either the speed of the anteater or slowly go to center - Bad Code, am changing

            if (!facingRight) //This checks if we are facing left, if we are we will flip.
            {

                Flip();
                facingRight = true;

            }

            moving = true; //I like to move it move it.
        }
        else if (positionToMoveTo.x - transform.position.x < 0.0f) //Or are we instead moving to the left?
        {

            moveX = Mathf.Max((positionToMoveTo.x - transform.position.x) / conversionX + transform.position.x, -speed / conversionX + transform.position.x); //Same as above line, only difference is we find the Max instead of Min - Bad Code, am also changing
            
            if (facingRight) //This checks if we are facing right, if we are we will flip.
            {

                Flip();
                facingRight = false;

            }

            moving = true; //You like to, move it!
        }
        else if (Mathf.Abs(positionToMoveTo.x - transform.position.x) < 0.01f) //...Uh I was trying to make the movement clamp off at a certain point, hopefully redundant come the lerping.
        {

            moveX = transform.position.x; //We move NOWHERE!
            moving = false; //I can't move it move it :(
        }
        else //Or if we are not moving at all we do the following.
        {

            moveX = transform.position.x; //We move NOWHERE!
            moving = false; //I can't move it move it :(

        }


        animator.SetBool("IsMoving", moving); //Sets the animator variable of moving?
        transform.position = new Vector3(moveX, -2.2f, transform.position.z); //We move along the X axis if movement is detected.

    }

    void Flip() //Flipping code to flip sprites
    {

        facingRight = !facingRight; //This sets facingRight to be the opposite of what it already is.
        Vector3 theScale = transform.localScale; //We get our scale from the transform.
        theScale.x *= -1; //By turning the scale from negative to positive or positive to negative we change what way the anteater is facing.
        transform.localScale = theScale; //We set the scale to be the newly calculated scale.

    }

}