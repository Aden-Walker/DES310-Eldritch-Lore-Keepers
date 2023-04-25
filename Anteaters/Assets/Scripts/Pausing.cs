using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale >= 1)
            {
                //Time.timeScale = 0f;
            }
            else
            {
                //Time.timeScale = 1f;
            }
        }
    }
}
