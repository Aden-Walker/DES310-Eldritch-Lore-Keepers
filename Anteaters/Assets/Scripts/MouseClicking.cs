using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicking : MonoBehaviour
{
    //more or less the player class

    //Animator for the Anteater
    Animator animator;

    Vector3 positionToMoveTo; //The position that we hope to get to.
    float moveX, speed, conversionX, conversionY, startTime, journeyLength; //A bunch of movement variables, moveX is how far we move in the horizontal direction, speed is how fast we go and the Conversion variables determine the rate at which speeds are divided.
    bool facingRight = true; //A variable to check if the anteater is facing right or not. Used for Flipping.
    void Start()
    {
        //We are initializing all of our variables here.
        animator = GetComponent<Animator>(); //Starts the animator? - Dominic
        positionToMoveTo = new Vector3(-4.25f, transform.position.y, transform.position.z); //Initialize our two movement points to be the starting position to prevent null values.
        transform.position = new Vector3(-4.25f, transform.position.y, transform.position.z);
        moveX = 0.0f;
        speed = 1.0f;
        conversionX = 900.0f;
        conversionY = 1600.0f;
        startTime = Time.time;

    }
    void Update()
    {
        bool moving = false; //We make sure that moving is false every frame until we determine it is true.
        if (Input.GetMouseButtonDown(0))
        {

            float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //How far away is the objects from the screen.
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen)); //The position we are at currently with our mouse
            positionToMoveTo = new Vector3(curPosition.x, curPosition.y, transform.position.z); //Where are we going? Where are we off to?

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen)), -Vector2.up); //A raycast for detection
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen)), new Vector2(0,-1)); //A ray itself seeing where the mouse is.

            if ((hit.collider != null) && (hit.collider.name == "Path"))
            {

                positionToMoveTo = new Vector3(hit.point.x, hit.point.y, transform.position.z);

            }

            //transform.position = Input.mousePosition;

            startTime = Time.time;

            journeyLength = Vector3.Distance(transform.position, positionToMoveTo);
            //clickPosition.position = Input.mousePosition;
            //this gives a point that can be used as a component in other objects
        }

        float distCovered;

        float fractionOfJourney = 1.0f;

        if (positionToMoveTo.x - transform.position.x != 0.0f)
        {

            distCovered = (Time.time - startTime) * speed * Time.deltaTime;

            fractionOfJourney = distCovered / journeyLength;

            Vector3 start = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, positionToMoveTo, fractionOfJourney);

            if (positionToMoveTo.x - transform.position.x > 0.0f) //Now we try to see if we are moving in the right direction.
            {

                if (!facingRight) //This checks if we are facing left, if we are we will flip.
                {

                    Flip();
                    facingRight = true;

                }

                moving = true; //I like to move it move it.
            }
            else if (positionToMoveTo.x - transform.position.x < 0.0f) //Or are we instead moving to the left?
            {

                if (facingRight) //This checks if we are facing right, if we are we will flip.
                {

                    Flip();
                    facingRight = false;

                }

                moving = true; //You like to, move it!
            }

            if (fractionOfJourney >= 0.1f)
            {

                moving = false;

            }

        }

        if (fractionOfJourney >= 0.9f)
        {

            moving = false;

        }

        /*if (positionToMoveTo.x - transform.position.x > 0.0f) //Now we try to see if we are moving in the right direction.
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

        }*/

        animator.SetBool("IsMoving", moving); //Sets the animator variable of moving?
        //transform.position = new Vector3(moveX, -2.2f, transform.position.z); //We move along the X axis if movement is detected.

    }

    void Flip() //Flipping code to flip sprites
    {

        facingRight = !facingRight; //This sets facingRight to be the opposite of what it already is.
        Vector3 theScale = transform.localScale; //We get our scale from the transform.
        theScale.x *= -1; //By turning the scale from negative to positive or positive to negative we change what way the anteater is facing.
        transform.localScale = theScale; //We set the scale to be the newly calculated scale.

    }

}