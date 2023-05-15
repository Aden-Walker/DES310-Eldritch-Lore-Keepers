using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTracking : MonoBehaviour
{
    // Simple parallax Script

    //variables to store shit. parallaxFactor should be a value between 0 and 1 higher values = less movement of the object
    private float startPos;
    private float camStartPos;
    private float angleRange;
    private float screenEdge;
    public float parallaxFactor;
    public float rotationFactor;
    public Transform cam;
    

    // Start is called before the first frame update
    void Start()
    {
        //store the start position of the object
        startPos = transform.position.x;
        camStartPos = cam.position.x;
        //initialise object's rotation if the rotation factor is 0 this changes nothing
        angleRange = 20 * rotationFactor;
        transform.eulerAngles = new Vector3(0, 0, -angleRange);
        screenEdge = cam.GetComponent<CameraTracking>().cameraEdgeX;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the camera is actually moving
        if (cam.position.x > camStartPos)
        {
            //figure out the distance that the object needs to move and then move it
            float distance = cam.position.x * parallaxFactor;
            Vector3 newPosition = new Vector3(startPos + distance, transform.position.y, transform.position.z);
            transform.position = newPosition;

            // find out the fraction of the screen that we have moved across then rotate appropriately
            float screenFraction = newPosition.x / screenEdge;
            //transform.Rotate(new Vector3(0, 0, -angleRange * (screenFraction * 2)));
            transform.eulerAngles = new Vector3(0, 0, -angleRange * (screenFraction * 2));

          
            
        }
        else
        {
            transform.position = new Vector3(startPos, transform.position.y, transform.position.z);

        }
    }
}