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
    
    void Start()
    {
        childStartPosition = child.transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!triggered && collision.name != "Path")
        {
            player.GetComponent<MouseClicking>().setWithChild(true);
            childFinalPosition = new Vector3(player.transform.position.x + 3, player.transform.position.y, player.transform.position.z);
            triggered = true;
            StartCoroutine(EndingMovement());
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator EndingMovement(float speed = 1.0f, float fractionOfJourney = 0.0f)
    {
        while (fractionOfJourney < 1)
        {
            fractionOfJourney += Time.deltaTime / speed;

            child.transform.position = Vector3.Lerp(childStartPosition, childFinalPosition, fractionOfJourney);

            yield return null;
        }
        yield break;
    }
}
