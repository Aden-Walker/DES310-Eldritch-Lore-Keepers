using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConclusionScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public GameObject child;

    private Vector3 childStartPosition;
    private Vector3 childFinalPosition;
    private bool triggered = false;

    // When the object is collided with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If it's not colliding with a path or has already been triggered
        if(!triggered && collision.name != "Path")
        {
            // Stop the ability to move for the player and get the position which the player will finish movement at
            player.GetComponent<MouseClicking>().setWithChild(true);
            Vector3 playerFinal = player.GetComponent<MouseClicking>().getAimPos();

            // Set start and end positions for the child then start the child movement
            childStartPosition = child.transform.position;
            childFinalPosition = new Vector3(playerFinal.x + 6, playerFinal.y, playerFinal.z);
            triggered = true;
            Debug.Log("Trigger Called, Child Start: " + childStartPosition + " Child End: " + childFinalPosition);
            child.GetComponent<Animator>().SetBool("IsMoving", true);
            StartCoroutine(EndingMovement(childStartPosition, childFinalPosition, 0.1f));
        }
            
    }

    public IEnumerator EndingMovement(Vector3 startPosition, Vector3 endPosition, float speed = 1.0f, float fractionOfJourney = 0.0f)
    {
        //simple lerp coroutine for the child moving down to the mother anteater

        while (fractionOfJourney < 1)
        {
            fractionOfJourney += Time.deltaTime / speed;

            child.transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
      
            yield return null;
        }

        child.GetComponent<Animator>().SetBool("IsMoving", false);
    
        yield break;
    }
}
