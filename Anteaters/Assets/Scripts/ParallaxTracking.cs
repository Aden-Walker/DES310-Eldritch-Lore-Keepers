using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTracking : MonoBehaviour
{
    // Simple parallax Script

    //variables to store shit. parallaxFactor should be a value between 0 and 1 higher values = less movement of the object
    private float startPos;
    public float parallaxFactor;
    public Transform cam;
    

    // Start is called before the first frame update
    void Start()
    {
        //store the start position of the object
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //figure out the distance that the object needs to move and then move it
        float distance = cam.position.x * parallaxFactor;
        Vector3 newPosition = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        transform.position = newPosition;
     
    }
}
