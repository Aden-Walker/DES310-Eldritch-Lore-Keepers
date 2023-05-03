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
    public GameObject choiceUI;
    public GameObject player;

    Animator playerAnimator;
    private bool transitioned = false;
    private bool buttonsFaded = false;
    private int sceneToGoTo;


    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Scene 1"))
        {
            StartCoroutine(ActivateChoices());
        }
        // checks if the transition has been completed
        if (transitioned)
        { 
            SceneManager.LoadScene(sceneToGoTo);
        }
    }

    //called when the object the script is attached to is collided with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ensures there's not a transition called when it shouldn't be
        if (collision.name != "Path")
        {
            //start the coroutine to fade the choice buttons in
            if(SceneManager.GetActiveScene().buildIndex != 1)
                StartCoroutine(ActivateChoices());
            else
                StartCoroutine(TransitionScene());
            Debug.Log("Trigger Called");
        }
    }

    public IEnumerator ActivateChoices(int fadeSpeed = 1)
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
            choiceUI.GetComponent<SpriteRenderer>().color = choiceColour;
            yield return null;
        }

        buttonsFaded = true;

        yield break;
    }

    // function to be called by the transition arrow object
    public void handleTransition(int scene)
    {
        sceneToGoTo = scene;
        if (buttonsFaded)
        {
            choiceOne.GetComponent<SpriteRenderer>().color = new Color(choiceOne.GetComponent<SpriteRenderer>().color.r, choiceOne.GetComponent<SpriteRenderer>().color.g, choiceOne.GetComponent<SpriteRenderer>().color.b, 0);
            choiceTwo.GetComponent<SpriteRenderer>().color = new Color(choiceTwo.GetComponent<SpriteRenderer>().color.r, choiceTwo.GetComponent<SpriteRenderer>().color.g, choiceTwo.GetComponent<SpriteRenderer>().color.b, 0);
            choiceUI.GetComponent<SpriteRenderer>().color = new Color(choiceUI.GetComponent<SpriteRenderer>().color.r, choiceUI.GetComponent<SpriteRenderer>().color.g, choiceUI.GetComponent<SpriteRenderer>().color.b, 0);
            StartCoroutine(TransitionScene());
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

    public void SetAnimatorParams(bool choices, bool child)
    {
        playerAnimator.SetBool("ChoicePicked", choices);
        playerAnimator.SetBool("WithChild", child);

        if (choices)
        {
            choiceOne.GetComponent<SpriteRenderer>().color = new Color(choiceOne.GetComponent<SpriteRenderer>().color.r, choiceOne.GetComponent<SpriteRenderer>().color.g, choiceOne.GetComponent<SpriteRenderer>().color.b, 0);
            choiceTwo.GetComponent<SpriteRenderer>().color = new Color(choiceTwo.GetComponent<SpriteRenderer>().color.r, choiceTwo.GetComponent<SpriteRenderer>().color.g, choiceTwo.GetComponent<SpriteRenderer>().color.b, 0);
            choiceUI.GetComponent<SpriteRenderer>().color = new Color(choiceUI.GetComponent<SpriteRenderer>().color.r, choiceUI.GetComponent<SpriteRenderer>().color.g, choiceUI.GetComponent<SpriteRenderer>().color.b, 0);
        }
            
    }
}
