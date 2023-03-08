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
        //get the current scene and store it for the switch statement
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        //ensure the camera does not show off screen
        if (modTracked.x < 0)
            modTracked.x = 0;
        //switch statement to stop the camera from scrolling too far. Bit of a dirty solution but eh. Screen halfwidth seems to be about 8.5
        switch(currentScene)
        {
            case 1:
                if (modTracked.x > 17.93)
                    modTracked.x = 17.93f;
               break;

        }
        //lock the camera's y value, can be handled in the scene switch if we want to introduce verticality
        modTracked.y = 0;
        //move the object towards the tracked object
        transform.position = Vector3.MoveTowards(transform.position, modTracked + offset, updateSpeed * Time.deltaTime);
    }
}
