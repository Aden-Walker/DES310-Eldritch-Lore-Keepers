using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{

    public GameObject transitionSquare;
    private bool transitioned = false;



    // Update is called once per frame
    void Update()
    {
        // checks if the transition has been completed
        if (transitioned)
        {
            //moves to the next scene, switch statement for future use
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            switch (currentScene)
            {
                case 1:
                    SceneManager.LoadScene(2);
                    break;
            }
        }
    }

    //called when the object the script is attached to is collided with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TransitionScene());
        Debug.Log("Trigger Called");
    }

    //coroutine to fade to black lower speed = slower transition time
    public IEnumerator TransitionScene(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        //stores the transition squares 
        Color objectColour = transitionSquare.GetComponent<Image>().color;
        float fadeAmount;

        if(fadeToBlack)
        {
            while(transitionSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColour.a + (fadeSpeed * Time.deltaTime);

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
                transitionSquare.GetComponent<Image>().color = objectColour;
                yield return null;
            }
        }
        else
        {
            while (transitionSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime);

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
                transitionSquare.GetComponent<Image>().color = objectColour;
                yield return null;
            }
        }
        transitioned = true;
        yield return new WaitForEndOfFrame();
    }
}
