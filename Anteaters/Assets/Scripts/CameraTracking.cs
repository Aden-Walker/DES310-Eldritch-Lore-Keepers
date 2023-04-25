using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTracking : MonoBehaviour
{
    //create variables to store shit
    public Transform trackedObject;
    public float updateSpeed = 3;
    public Vector2 trackingOffset;
    public float cameraEdgeX;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - trackedObject.position.z;
    }

    // Update is called once per frame after Update is called
    void LateUpdate()
    {
        //store the object's position in a variable we can edit
        Vector3 modTracked = trackedObject.position;
        //ensure the camera does not show off screen
        if (modTracked.x < 0)
            modTracked.x = 0;
        //simply just takes the passed in value and makes sure the camera does not go past that point
        if (modTracked.x > cameraEdgeX)
            modTracked.x = cameraEdgeX;
        //lock the camera's y value, can be handled in the scene switch if we want to introduce verticality
        modTracked.y = 0;
        //move the object towards the tracked object
        transform.position = Vector3.MoveTowards(transform.position, modTracked + offset, updateSpeed * Time.deltaTime);
    }
}
