using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MouseClicking : MonoBehaviour
{
    //more or less the player class

    //Animator for the Anteater
    Animator animator;

    Vector3 positionToMoveTo; //The position that we hope to get to.
    float speed, startTime, journeyLength; //A bunch of movement variables, moveX is how far we move in the horizontal direction, speed is how fast we go and the Conversion variables determine the rate at which speeds are divided.
    bool facingRight = true; //A variable to check if the anteater is facing right or not. Used for Flipping.
    bool moving = false;
    float distCovered = 0.0f;
    float fractionOfJourney = 0.0f;
    Vector3 startPos;

    void Start()
    {
        //We are initializing all of our variables here.
        //gets the animator component
        animator = GetComponent<Animator>();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        animator.SetInteger("SceneNumber", currentScene);
        positionToMoveTo = new Vector3(-4.25f, transform.position.y, transform.position.z); //Initialize our two movement points to be the starting position to prevent null values.
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speed = 3.0f;
        StartCoroutine(EnterScene(transform.position, positionToMoveTo, 2));
    }
    void Update()
    {
        //check if the mouse has been clicked and that the player is not currently moving
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("WithChild"))
        {
            //set the start time to when the time when the mouse was clicked
            startTime = Time.time;
            float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //How far away is the objects from the screen.
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen)); //The position we are at currently with our mouse
            positionToMoveTo = new Vector3(curPosition.x, curPosition.y, transform.position.z); //Where are we going? Where are we off to?

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen)), -Vector2.up); //A raycast for detection
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen)), new Vector2(0,-1)); //A ray itself seeing where the mouse is.

            if ((hit.collider != null) && (hit.collider.name == "Path"))
            {

                positionToMoveTo = new Vector3(hit.point.x, hit.point.y, transform.position.z);

            }

            //zero the distance covered and fraction of the journey
            distCovered = 0.0f;
            fractionOfJourney = 0.0f;
            journeyLength = Vector3.Distance(transform.position, positionToMoveTo);
            startPos = transform.position;
            moving = true;
           
        }

        //check if the journey is over
        if (fractionOfJourney >= 0.99f)
        {
            //stop the movement animation
            moving = false;
        }

        //if the player is still moving
        if (moving == true)
        {
            //set the current distance covered to the difference between the current time and the start time
            distCovered = (Time.time - startTime) * speed;
            
            float prevfoJ = fractionOfJourney;

            //set the fraction of the journey covered
            fractionOfJourney = distCovered / journeyLength;


            LayerMask mask = LayerMask.GetMask("Default");

            RaycastHit2D hit = Physics2D.Raycast(Vector3.Lerp(startPos, positionToMoveTo, fractionOfJourney), -Vector2.up, Mathf.Infinity, mask); //A raycast for detection

            if ((hit.collider != null) && (hit.collider.name == "Path"))
            {

                if (hit.distance > 0.0f)
                {

                    fractionOfJourney = prevfoJ;
                    moving = false;

                }


            }

            //lerp the player's positiong using the start position, the position to move to and the current fraction of the journey
            transform.position = Vector3.Lerp(startPos, positionToMoveTo, fractionOfJourney);

            if (positionToMoveTo.x - transform.position.x > 0.0f) //Now we try to see if we are moving in the right direction.
            {
                if (!facingRight) //This checks if we are facing left, if we are we will flip.
                {

                    Flip();
                    facingRight = true;

                }
            }
            else if (positionToMoveTo.x - transform.position.x < 0.0f) //Or are we instead moving to the left?
            {
                if (facingRight) //This checks if we are facing right, if we are we will flip.
                {

                    Flip();
                    facingRight = false;

                }
            }


        }

        //passes the animator parameter 
        animator.SetBool("IsMoving", moving); 

    }

    void Flip() //Flipping code to flip sprites
    {

        facingRight = !facingRight; //This sets facingRight to be the opposite of what it already is.
        Vector3 theScale = transform.localScale; //We get our scale from the transform.
        theScale.x *= -1; //By turning the scale from negative to positive or positive to negative we change what way the anteater is facing.
        transform.localScale = theScale; //We set the scale to be the newly calculated scale.

    }


    public IEnumerator EnterScene(Vector3 startPosition, Vector3 endPosition,float entrySpeed = 1.0f, float fractionOfJourney = 0.0f)
    {
        while(fractionOfJourney < 1)
        {
            fractionOfJourney += Time.deltaTime / entrySpeed;

            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);

            yield return null;
        }

        animator.SetBool("WithChild", false);

        yield break;
    }

}