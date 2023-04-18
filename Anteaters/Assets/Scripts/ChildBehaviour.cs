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
    
    // Start is called before the first frame update
    void Start()
    {
        childStartPosition = player.transform.position;
        
        childColor = GetComponent<SpriteRenderer>().color;
        movementNumber = 1;
        GetComponent<SpriteRenderer>().color = new Color(childColor.r, childColor.g, childColor.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.GetComponent<Animator>().GetBool("WithChild") && !active)
        {
            active = true;
            GetComponent<SpriteRenderer>().color = childColor;
        }
        if(active)
        {
            if (!GetComponent<Animator>().GetBool("IsMoving"))
            {
                switch (movementNumber)
                {
                    case 1:
                        GetComponent<Animator>().SetBool("IsMoving", true);
                        StartCoroutine(LerpMovement(childStartPosition, firstEndPos.position));
                        break;
                    case 2:
                        GetComponent<Animator>().SetBool("IsMoving", true);
                        StartCoroutine(LerpMovement(firstEndPos.position, secondEndPos.position));
                        break;
                    case 3:
                        GetComponent<Animator>().SetBool("IsMoving", true);
                        StartCoroutine(LerpMovement(secondEndPos.position, thirdEndPos.position));
                        break;
                    case 4:
                        GetComponent<Animator>().SetBool("IsMoving", true);
                        StartCoroutine(LerpMovement(thirdEndPos.position, fourthEndPos.position));
                        break;
                    case 5:

                }
            }
        }
    }

    public IEnumerator LerpMovement(Vector3 start, Vector3 end, float fractionOfJourney = 0.0f, float speed = 0.5f)
    {
        while(fractionOfJourney < 1)
        {
            fractionOfJourney += Time.deltaTime / speed;

            transform.position = Vector3.Lerp(start, end, fractionOfJourney);

            yield return null;

        }

        GetComponent<Animator>().SetBool("IsMoving", false);

        yield break;
    }


    public void IncrementMovement()
    {
        movementNumber++;
    }
}
