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
    public GameObject choiceOne;
    public GameObject choiceTwo;
    private bool transitioned = false;
    private int sceneToGoTo;
    
    
    // Update is called once per frame
    void Update()
    {
     
        // checks if the transition has been completed
        if (transitioned)
        { 
            SceneManager.LoadScene(sceneToGoTo);
        }
    }

    //called when the object the script is attached to is collided with
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Vector3 buttonOneStartPos = choiceOne.transform.position;
        Vector3 buttonTwoStartPos = choiceTwo.transform.position;
        Vector3 buttonOneEndPos = new Vector3(buttonOneStartPos.x, 0, buttonOneStartPos.z);
        Vector3 buttonTwoEndPos = new Vector3(buttonTwoStartPos.x, 0, buttonOneEndPos.z);

        StartCoroutine(ActivateChoices(buttonOneStartPos, buttonOneEndPos, buttonTwoStartPos, buttonTwoEndPos));
        Debug.Log("Trigger Called");

    }

    public IEnumerator ActivateChoices(Vector3 buttonOneStart, Vector3 buttonOneEnd, Vector3 buttonTwoStart, Vector3 buttonTwoEnd, int fadeSpeed = 1, float fractionOfJourney = 0.0f)
    {
        //pretty much the same as the transition code might modify to make the choice slide into place instead of fading

        Color choiceColour = choiceOne.GetComponent<SpriteRenderer>().color;
        float fadeAmount;

        while (choiceOne.GetComponent<SpriteRenderer>().color.a < 1)
        {
            fadeAmount = choiceColour.a + (fadeSpeed * Time.deltaTime);

            choiceColour = new Color(choiceColour.r, choiceColour.g, choiceColour.b, fadeAmount);
            choiceOne.GetComponent<SpriteRenderer>().color = choiceColour;
            choiceTwo.GetComponent<SpriteRenderer>().color = choiceColour;
            yield return null;
        }



        //while (fractionOfJourney < 1)
        //{
        //    fractionOfJourney += Time.deltaTime;

        //    choiceOne.transform.position = Vector3.Lerp(buttonOneStart, buttonOneEnd, fractionOfJourney);
        //    choiceTwo.transform.position = Vector3.Lerp(buttonTwoStart, buttonTwoEnd, fractionOfJourney);

        //    yield return null;
        //}


        yield return new WaitForEndOfFrame();
    }

    // function to be called by the transition arrow object
    public void handleTransition(int scene)
    {
        sceneToGoTo = scene;
        StartCoroutine(TransitionScene());
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
