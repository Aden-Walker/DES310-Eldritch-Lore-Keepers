using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{

    public GameObject transitionSquare;
    public GameObject foreground;
    public GameObject background;
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
        if (collision.name != "Path")
        {
            StartCoroutine(TransitionScene());
            Debug.Log("Trigger Called");
        }
    }

    //coroutine to fade to black lower speed = slower transition time
    public IEnumerator TransitionScene(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        //stores the colours of the transition square, background and foreground
        Color objectColour = transitionSquare.GetComponent<Image>().color;
        Color bgColour = background.GetComponent<SpriteRenderer>().color;
        Color fgColour = foreground.GetComponent<SpriteRenderer>().color;

        //intialises floats for the fade amounts
        float fadeAmount;
        float inverseFadeAmount;

        //if we are fading to black
        if(fadeToBlack)
        {
            // while the transition square's alpha is less than 1
            while(transitionSquare.GetComponent<Image>().color.a < 1)
            {
                //increase the fade amount value
                fadeAmount = objectColour.a + (fadeSpeed * Time.deltaTime);
                inverseFadeAmount = 1 - fadeAmount;

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
                transitionSquare.GetComponent<Image>().color = objectColour;
                bgColour = new Color(bgColour.r, bgColour.g, bgColour.b, inverseFadeAmount);
                background.GetComponent<SpriteRenderer>().color = bgColour;
                fgColour = new Color(fgColour.r, fgColour.g, fgColour.b, inverseFadeAmount);
                foreground.GetComponent<SpriteRenderer>().color = fgColour;
                yield return null;
            }
        }
        else
        {
            while (transitionSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime);
                inverseFadeAmount = 0 + fadeAmount;

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
                transitionSquare.GetComponent<Image>().color = objectColour;
                yield return null;
            }
        }
        transitioned = true;
        yield return new WaitForEndOfFrame();
    }
}
