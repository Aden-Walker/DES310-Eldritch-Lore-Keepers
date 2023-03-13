using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTracking : MonoBehaviour
{
    // generic tracking script seperate from the camera

    public Transform trackedObject;
    public float trackingSpeed;
    public Vector2 trackingOffset;
    public Vector2 boundLeft;
    public Vector2 boundRight;
    private Vector3 offset;
    

    // Start is called before the first frame update
    void Start()
    {
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - trackedObject.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 modTracked = trackedObject.position;
        // Check if out of bounds, if so return to bounds
        if (modTracked.x < boundLeft.x)
            modTracked.x = boundLeft.x;
        if (modTracked.x > boundRight.x)
            modTracked.x = boundRight.x;
        if (modTracked.y > boundLeft.y)
            modTracked.y = boundLeft.y;
        // Move the object
        transform.position = Vector3.MoveTowards(transform.position, modTracked + offset, trackingSpeed * Time.deltaTime);
    }
}
