using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBehaviour : MonoBehaviour
{

    public GameObject player;
    public Transform firstEndPos;
    public Transform secondEndPos;
    public Transform thirdEndPos;
    public Transform fourthEndPos;
    public Transform finalEndPos;
    public int movementNumber;
    


    private Vector3 childStartPosition;
    private Color childColor;
    private bool active = false;
    private bool lerpCompleted = false;
    // Start is called before the first frame update
    void Start()
    {
        // store the child's colour set in the editor
        childColor = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 1);
        movementNumber = 0;
        GetComponent<SpriteRenderer>().color = new Color(childColor.r, childColor.g, childColor.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // check if the player is dismounted and if the child is already active or not
        if(!player.GetComponent<Animator>().GetBool("WithChild") && !active)
        {
            // set the child to be active and initialise variables
            active = true;
            childStartPosition = player.transform.position;
            GetComponent<SpriteRenderer>().color = childColor;
        }
        if(active)
        {
            //check if the child is moving
            if (!GetComponent<Animator>().GetBool("IsMoving"))
            {
                // check what movement we are on and start appropriate lerp
                switch (movementNumber)
                {
                    case 0:
                        GetComponent<Animator>().SetBool("IsMoving", false);
                        break;
                    case 1:
                        if (!lerpCompleted)
                        {
                            GetComponent<Animator>().SetBool("IsMoving", true);
                            StartCoroutine(LerpMovement(childStartPosition, firstEndPos.position));
                        }
                        break;
                    case 2:
                        if (!lerpCompleted)
                        {
                            GetComponent<Animator>().SetBool("IsMoving", true);
                            StartCoroutine(LerpMovement(firstEndPos.position, secondEndPos.position));
                        }
                        break;
                    case 3:
                        if (!lerpCompleted)
                        {
                            GetComponent<Animator>().SetBool("IsMoving", true);
                            StartCoroutine(LerpMovement(secondEndPos.position, thirdEndPos.position));
                        }
                        break;
                    case 4:
                        if (!lerpCompleted)
                        {
                            GetComponent<Animator>().SetBool("IsMoving", true);
                            StartCoroutine(LerpMovement(thirdEndPos.position, fourthEndPos.position));
                        }
                        break;
                    case 5:
                        if (!lerpCompleted)
                        {
                            GetComponent<Animator>().SetBool("IsMoving", true);
                            StartCoroutine(LerpMovement(fourthEndPos.position, finalEndPos.position));
                        }
                        break;
                    default:
                        // if we are here we are in hell
                        break;

                }
            }
        }

       
    }

    public IEnumerator LerpMovement(Vector3 start, Vector3 end, float fractionOfJourney = 0.0f, float speed = 1.0f)
    {
        // simple lerp movement coroutine, same as the others
        while(fractionOfJourney < 1)
        {
            fractionOfJourney += Time.deltaTime / speed;

            transform.position = Vector3.Lerp(start, end, fractionOfJourney);

            yield return null;

        }

        GetComponent<Animator>().SetBool("IsMoving", false);

        lerpCompleted = true;
        yield break;
    }


    public void IncrementMovement()
    {
        lerpCompleted = false;
        movementNumber++;
    }
}
