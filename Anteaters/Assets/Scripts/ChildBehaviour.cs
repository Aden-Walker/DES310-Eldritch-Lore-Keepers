using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBehaviour : MonoBehaviour
{

    public GameObject player;

    private Vector3 childStartPosition;
    private bool active = false;
    
    // Start is called before the first frame update
    void Start()
    {
        childStartPosition = player.transform.position;
        Color childOriginalColor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(childOriginalColor.r, childOriginalColor.g, childOriginalColor.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.GetComponent<Animator>().GetBool("WithChild") && !active)
        {
            active = true;
        }
        if(active)
        {
            
        }
    }
}
